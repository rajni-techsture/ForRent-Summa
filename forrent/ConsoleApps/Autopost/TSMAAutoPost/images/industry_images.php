<?php session_start(); ?>
<?php include_once("../config.php"); ?>
<?php 
define('FACEBOOK_APP_URL',APP_URL);
$PageLink = SITE_URL.ADMIN_PATH.basename($_SERVER['PHP_SELF']).'?';
include_once(DOC_ROOT."includes/functions.php");
include_once(DOC_ROOT."includes/site_functions.php"); ?>
<?php 
//print_array($_REQUEST);

###############################################################################
// Set file Uploadfile true to allow file uploading and define the file type
###############################################################################
$Uploadfile=true;
$allowed_file_type = array('jpg','jpeg','gif','png');
###############################################################################

###############################################################################
// Set request variable as key and set its value for error message
###############################################################################
$VAR_REQUEST['title']='Please enter the message ' ;
$VAR_REQUEST['industry']='Please enter the type ' ;
$formdata="";
foreach($VAR_REQUEST as $key => $val)
{
	$$key = isset($_REQUEST[$key])	?  mysql_query_string($_REQUEST[$key]) : '';
	$formdata.="&$key=".$$key;
}

################################################################################

$id 		= isset($_REQUEST['id'])		?	$_REQUEST['id']	:	0;
$date		= isset($_REQUEST['date'])		? 	mysql_query_string($_REQUEST['date']) : " SYSDATE()";
$display 	= isset($_REQUEST['display'])	?	$_REQUEST['display']	:	"List";
$Action		= isset($_REQUEST['Action'])	?	$_REQUEST['Action']	:	"";
$image = (isset($_FILES['image']) AND $_FILES['image']['size'] > 0 AND $_FILES['image']['error'] == 0) ? $_FILES['image'] : "";
$status		= isset($_REQUEST['status']) 	? $_REQUEST['status'] : 1;
$url		= isset($_REQUEST['url']) 	? $_REQUEST['url'] : '';
$video		= isset($_REQUEST['video']) 	? $_REQUEST['video'] : '';
if(!isset($_REQUEST['orderby'])) $_REQUEST['orderby'] = "date";
if(!isset($_REQUEST['sortby'])) $_REQUEST['sortby'] = "desc";
#####################################################################################
// Set  table message and query , the query will join with insert and update queries
#####################################################################################
//$_SESSION['industry']=isset($_REQUEST['industry'])?$_REQUEST['industry']:$_SESSION['industry'];
//$industry_name = $_SESSION['industry'];
$table= 'industry_images';
$query=", title='$title',industry='$industry' ";
######################################################################################




//include_once("sortorder.php"); 

 #	ERRORS AND VALIDATIONS

if($Action == "Add" OR $Action == "Update")
{
	
	foreach($VAR_REQUEST as $key => $val)
	{
		if($$key == "")
		{
		$_SESSION['msg'][]=$val;
		}		
	}

//image uploading 	
	if(is_array($image) and $Uploadfile==true)	# CHECK UPLOADED FILE FOR VALIDATION
	{
		# CHECK FILE TYPE IF IT IS IMAGE JPG,GIF,PNG ETC
		$fnarr = explode(".", $image['name']);
		$file_extension = strtolower($fnarr[count($fnarr)-1]);
		if(in_array($file_extension,$allowed_file_type))
		{
			#	GO AHEAD, THESE FILE TYPE ALLOWED
			$image['name'] = substr(md5($image['name'].time()),5,15).".".$file_extension;
		}
		else
		{	
			$_SESSION['msg'][]	=	"Invalid File type! please upload only ".implode(",",$allowed_file_type)." files.";
		}
	}
	elseif($Action == "Add" and $Uploadfile==true){
	//$_SESSION['msg'][]	=	"Please upload file...";
	unset($image);
	}

	if(isset($_SESSION['msg']))
	{
		$_REQUEST['display'] = $Action;
		$_REQUEST['Action'] = "";

		//$formdata = http_build_query($_POST);

		# redirect to same page again for error correction
		$comma_separated_ermsg = implode(",", $_SESSION['msg']);
		unset($_SESSION['msg']);
		//echo "<fb:redirect url=\"".FACEBOOK_APP_URL.ADMIN_PATH.basename($_SERVER['PHP_SELF'])."?comma_separated_ermsg=$comma_separated_ermsg&status=$status$formdata\" />";
		header( "Location: ".SITE_URL.ADMIN_PATH.basename($_SERVER['PHP_SELF'])."?comma_separated_ermsg=$comma_separated_ermsg&status=$status$formdata&display={$_POST['Action']}" ); 
		//echo "<meta http-equiv=\"refresh\" content=\"0;URL=".FACEBOOK_APP_URL.ADMIN_PATH.basename($_SERVER['PHP_SELF'])."?comma_separated_ermsg=$comma_separated_ermsg&$formdata\" />";
		exit;

		$display = $Action;
		$Action = "";
	}
}
//	ADD 
if($Action	==	"Add")
{
	//	UPLOADING PROCESS 
	if(is_array($image) and $Uploadfile==true)
	{
	echo 'yes array';die;
		$file_type	=	$image['type'];

		if(is_dir(ROOT.'images/'))
		{
			$file	=	ROOT.'images/'.$image['name'];
			echo $file;
			
			
			if(move_uploaded_file($image['tmp_name'],$file))
			{
				$image	=	$image['name'];
			}
			else
			{
				$image	=	"";
			}
		}
		else
		{
			echo "dir images not exist";
			exit(include ("footer.php"));
		}
	}
	
	$isimage=$image!=""?",image='$image'":"";
	echo $sql = "INSERT INTO `$table` SET 
	status = '$status'
	$isimage
	,date=$date $query
	" ;die;
	if(!mysql_query($sql)){exit(debug($sql).mysql_error());}
	
	$_SESSION['msg'][] = "Record successfully added!";
	
	$comma_separated_ermsg = implode(",", $_SESSION['msg']);
	unset($_SESSION['msg']);
	//echo "<fb:redirect url=\"".FACEBOOK_APP_URL.ADMIN_PATH.basename($_SERVER['PHP_SELF'])."?id=$id&comma_separated_ermsg=$comma_separated_ermsg\" />";
	header( "Location: ".SITE_URL.ADMIN_PATH.basename($_SERVER['PHP_SELF'])."?comma_separated_ermsg=$comma_separated_ermsg&$formdata" ); 
	//echo "<meta http-equiv=\"refresh\" content=\"0;URL=".FACEBOOK_APP_URL.ADMIN_PATH.basename($_SERVER['PHP_SELF'])."?id=$id&comma_separated_ermsg=$comma_separated_ermsg\" />";
	exit;	
}else {die('No array ');}

//	END UPLAoDING
?>
<?php

// Delete Query
if($Action == "delete")
{
	if($Uploadfile==true)
	{
		$sql = "SELECT image FROM `$table` WHERE id=$id";
		$result = mysql_query($sql) or die(debug($sql).mysql_error());
		while($row = mysql_fetch_array($result))
		{
			delete_file(ROOT.'images/'.$row['image']);
		}
	}
	
	$sql="delete from `$table` where id = $id ";
	if(!mysql_query($sql)){exit(debug($sql).mysql_error());}
	
	$_SESSION['msg'][0]	=	"Record has been Deleted successfully...";

	$comma_separated_ermsg = implode(",", $_SESSION['msg']);
	unset($_SESSION['msg']);
	//echo "<fb:redirect url=\"".FACEBOOK_APP_URL.ADMIN_PATH.basename($_SERVER['PHP_SELF'])."?comma_separated_ermsg=$comma_separated_ermsg\" />";
	header( "Location: ".SITE_URL.ADMIN_PATH.basename($_SERVER['PHP_SELF'])."?comma_separated_ermsg=$comma_separated_ermsg" ); 
	//echo "<meta http-equiv=\"refresh\" content=\"0;URL=".FACEBOOK_APP_URL.ADMIN_PATH.basename($_SERVER['PHP_SELF'])."?comma_separated_ermsg=$comma_separated_ermsg\" />";
	exit;	
}
//Update Query
if($Action == "Update")
{
	$Delete1 = isset($_REQUEST['Delete1']) ? $_REQUEST['Delete1'] : 0;
	$oldfile = isset($_REQUEST['oldfile']) ? $_REQUEST['oldfile'] : 0;
	if(is_array($image)){ $Delete1 = 1;}
	
	//	DELETE FILE
	if($Delete1 and $Uploadfile==true)
	{
		if(delete_file(ROOT.'images/'.$oldfile))
		{
			//$_SESSION['msg'][]	=	"$delete_image file deleted...";
		}
		else
		{
			//$_SESSION['msg'][] = "Error Deleting $oldfile";
		}

		$sql="UPDATE `$table` SET `image`='' WHERE id=$id ";
		if (!mysql_query($sql)){exit("$sql<br>\n".mysql_error());}
	}
	//	UPLOADING PROCESS FOR Item 1
	if(is_array($image) and $Uploadfile==true)
	{
		$file_type	=	$image['type'];
		if(is_dir(ROOT.'images/'))
		{
			$file=ROOT.'images/'.$image['name'];
			if(move_uploaded_file($image['tmp_name'],$file))
			{
				$image	=	$image['name'];
				
				# update image
				$sql = "update `$table` set image='$image' where id=$id ";
				if(!mysql_query($sql)){exit(debug($sql).mysql_error());}
			}
			else
			{
				$image	=	"";
			}
		}
		else
		{
			echo "dir  images  not exist";
			exit(include ("footer.php"));
		}
	}
	
	$sql="Update `$table` set 
	status = '$status',
	date=$date $query 
	where id = '$id' ";

	if (!mysql_query($sql)){exit(debug($sql).mysql_error());}
	
	$_SESSION['msg'][]	=	"Record has been Updated successfully...";
	
	$comma_separated_ermsg = implode(",", $_SESSION['msg']);
	unset($_SESSION['msg']);
	//echo "<fb:redirect url=\"".FACEBOOK_APP_URL.ADMIN_PATH.basename($_SERVER['PHP_SELF'])."?comma_separated_ermsg=$comma_separated_ermsg\" />";
	header( "Location: ".SITE_URL.ADMIN_PATH.basename($_SERVER['PHP_SELF'])."?comma_separated_ermsg=$comma_separated_ermsg&$formdata" );
	//echo "<meta http-equiv=\"refresh\" content=\"0;URL=".FACEBOOK_APP_URL.ADMIN_PATH.basename($_SERVER['PHP_SELF'])."?comma_separated_ermsg=$comma_separated_ermsg\" />";
	exit;	
}

?>
<?php
if(isset($_REQUEST['comma_separated_ermsg']) && $_REQUEST['comma_separated_ermsg'] != "")
{
	$_SESSION['msg'] = explode(",",$_REQUEST['comma_separated_ermsg']);
}
?>
<?php include_once("header.php"); ?>
<?php  echo display_error(); ?>
<?php
//	ADD OR UPDATE FORM
if($display == "Update")
{
	$sql = "SELECT * FROM `$table` WHERE id = $id ";
	$result= mysql_query($sql) or die(debug($sql).mysql_error());

	while ($row	=	mysql_fetch_array($result))
	{
		$id = $row['id'];
		$status = $row['status'];
		$image = $Uploadfile==true?$row['image']:'';
		$date=$row['date'];
		$message = $row['message'];
		$type = $row['type'];
		$url = $row['url'];
		$video = $row['video'];
	}
}
if($display == "Add" OR ($display == "Update" AND $id > 0))
{
?>
<form id="dummy_form" name="dummy_form"></form>
<form action="<?php echo SITE_URL.ADMIN_PATH; ?><?php echo basename($_SERVER['PHP_SELF']) ;?>" method="post" enctype="multipart/form-data" name="myform">
  <table width="100%" border="0" cellpadding="0" cellspacing="5">
<tr>
  <td align="left" valign="top" class="login_txt"><INPUT TYPE="button" VALUE="Back" onClick="history.go(-1);return true;"></td>
  <td align="left">&nbsp;</td>
</tr>
<tr>
  <td colspan="2" align="center" valign="top">
  <table width="421" border="0" align="center" cellpadding="2" cellspacing="3" class="border" style="background-color: #E2E6F3;">
     <tr>
       <td colspan="2" align="center" class="bodyblackbold"><div align="left">
         <div class="bodyblackbold"><?php echo $display .' '.str_replace('_',' ',$table); ?></div>
       </div>
         </div></td>
       </tr>
     
     <tr>
      <td width="36%" align="left" valign="top" class="uploadtext" style="padding-left:15px;">Title</td>
      <td width="64%" align="left"><input type="text" name="title" id="title" value="<?php echo $row['title']?>"  /></td>
    </tr>
    
	<tr>
      <td align="left" valign="top" class="uploadtext" style="padding-left:15px;"><span class="bodytext">Industry: </span></td>
      <td align="left">
	  <select name="industry" id="industry" >
	  <option value="">Select Industry</option>
	 <?php 
	 $sql = "select cat_name from industry_cat where status='1' ";
	 $res = mysql_query($sql) or die($sql.mysql_error());
	 while ($row = mysql_fetch_assoc($res)){
	 ?>
	  <option value="<?php echo $row['cat_name'];?>" <?php echo $row['cat_name']==$industry?'selected="selected"':'';?>><?php echo $row['cat_name'];?></option><?php }?>
	  </select>
	  <!--<input name="type" type="text"  id="type" class="border" value="<?php //echo stripslashes($type);  ?>" />	 --> </td>
    </tr>
    <tr>
  <td align="left" valign="top" class="bodytext" style="padding-left:15px;">Status:</td>
  <td align="left">
  <?php
	// GET status COMBO BOX
	$box_array['sql']	=	"select title,value from dropdownitems where itemtype='status' ORDER BY sort_order";
	$box_array['title_field']	=	"title";
	$box_array['value_field']	=	"value";
	$box_array['combobox_name']	=	"status";
	$box_array['select_value']	=	$status;
	$box_array['default_title'] = 	0;
	echo combobox($box_array);
?></td>
</tr>

<tr>
  <td align="left" valign="top" class="bodytext" style="padding-left:15px;"><!--Video URL:--></td>
  <td><input name="video" type="hidden"  id="video" class="border" value="<?php echo stripslashes($video);  ?>" /></td>
</tr>

<tr>
  <td align="left" valign="top" class="bodytext" style="padding-left:15px;">&nbsp;</td>
  <td>&nbsp;</td>
</tr>

 <?php if($Uploadfile==true)
	  {
	  ?>
<tr>
<td class="uploadtext" style="padding-left:15px;">Image:</td>
<td>
 <?php if($display == "Update" AND $image!= "")
{
$filemessage = 'images/'.$image;
echo "<img src=\"".SITE_URL."thumb.php?src=$filemessage&dest=$filemessage&x=200&y=225&f=0\" border=\"0\" /><br>";
echo "<label>$image <input name=\"Delete1\" type=\"checkbox\" id=\"Delete1\" value=\"1\" />Delete</label><input message=\"oldfile\" type=\"hidden\" value=\"$image\" /><br>";
}?>
<label>
<input type="file" name="image" id="image" class="border" />
</label></td>
</tr>
<?php
}
?>
<tr>
  <td valign="top" class="login_txt">&nbsp;</td>
  <td>&nbsp;</td>
</tr>
<tr>
<td valign="top" class="login_txt"><input type="hidden" name="Action" value="<?php echo $display; ?>"  />
<input type="hidden" name="id" value=<?php echo $id; ?>  /><input type="hidden" name="user_id" value=<?php echo $user_id; ?>  /></td>
<td><input type="submit" class="border" name="submit" value="<?php echo $display; ?>"  /></td>
</tr>
<tr>
  <td valign="top" class="login_txt">&nbsp;</td>
  <td>&nbsp;</td>
</tr>
  </table></td>
  </tr>
<tr>
  <td align="left" valign="top" class="login_txt">&nbsp;</td>
  <td align="left">&nbsp;</td>
</tr>
</table>

</form>
<?php 
}
elseif($display == "List")
{
	$sql = "SELECT * from `$table` order by id desc";
	//////////////////PAGINATION STARTS HERE////////////
	$sqlCount = $sql;	
	$rsCount = mysql_query($sqlCount);
	$totalrows = mysql_num_rows($rsCount);
	$limit=10;
	if(isset($_REQUEST['page'])){$page	=	$_REQUEST['page'];}
	else{
		$page = 1;
	}
	$limitvalue = ($page - 1) * $limit;			
	ob_start();
	if($page > 1){
	  $pageprev = $page-1;
	  echo("<a href=\"".$PageLink."page=$pageprev\">&lt;</a>&nbsp;");
	}			                                                            
	$numofpages = ceil($totalrows / $limit);
	for($i = 1; $i <= $numofpages; $i++)
	{
		if($i > $page-10 and $i < $page+10)
		{
			if($page == $i)
				echo($i."&nbsp;");
			else
				echo("<a href=\"".$PageLink."page=$i\">$i</a>&nbsp;");
		}
	}			
	if($page < $numofpages){
		$pagenext = ($page + 1);
		echo ("<a href=\"".$PageLink."page=$pagenext\">&gt;</a>");
	}		
	$pagination = ob_get_contents();
	ob_end_clean();

	$sql.=	" LIMIT $limitvalue, $limit";
	//echo $sql;
	$res = mysql_query($sql) or die(debug($sql).mysql_error());
	$total_displaying = mysql_num_rows($res);
	$starting = ($total_displaying > 0) ? $limitvalue+1 : 0;
	$ending = $limitvalue+$total_displaying;
	//////////////// PAGINATION ENDS HERE////////////
	
    ?>
<form action="<?php basename($_SERVER['PHP_SELF']); ?>" method="post" enctype="multipart/form-data" name="form2">
<table width="100%" border="0" cellpadding="2" cellspacing="3">
  <tr>
    <td colspan="6" align="left" ><a href="<?php echo APP_URL;?>admin/industry_cat.php" target="_top">Go Back To Industry Category</a> </td>
  </tr>
  <tr>
    <td colspan="6" align="left">
	<table width="100%" border="0" cellspacing="2" cellpadding="0" style="background-color: #EFEECF;" class="border">
      <tr>
        <td width="57" align="center"><img src="<?php echo IMAGE_PATH; ?>plus.png" border="0" width="39" height="40" /></td>
        <td width="478" style="padding-left:10px;"><a href="<?php echo basename($_SERVER['PHP_SELF']); ?>?display=Add" title="Add Frame"><strong>Add <?php echo str_replace('_',' ',$table) ;?> feeds </strong></a></td>
        <td width="478" style="padding-left:10px;">&nbsp;</td>
        <td width="405" style="padding-left:10px;">&nbsp;</td>
      </tr>
    </table>      </td>
  </tr>
   <tr  style="background-color:#F4F4F4;">
   <td width="40"><div align="center" class="bodyblackbold"><strong>Image </strong></div></td>
    <td><div align="center" class="bodyblackbold"><strong>Title </strong></div></td>
	<td width="61"><div align="center" class="bodyblackbold"><strong>Industry </strong></div></td>
	
    
    <td width="199"><div align="center" class="bodyblackbold"><strong>Action</strong></div></td>
   </tr>
  <?php
  if($totalrows > 0)
	{	$chk = 0;
	?>
  <?php
		while ($row	=	mysql_fetch_array($res)) 
		{
		$id = $row['id'];
		$image = $Uploadfile==true?$row['image']:'';
		$status = $row['status'];
		$date=$row['date'];
		//$char_image = ($row['char_image']!="")?$row['char_image']:"no_image.jpg";
		if(!isset($color)){ $color	=	COLOR1;} if($color == COLOR2){$color	=	COLOR1;}else{$color	=	COLOR2;}
	   ?>
  <tr bgcolor="<?php echo $color; ?>">
    <td width="40" align="">    
    
	  
	  <div class="bodytext" align="center"><?php echo $image!=''?'<img src="../images/'.$image.'" height="50">':'no image'; ?></div>
	<td width="255" align="">    
     <div align="" style="padding:10px;"><?php echo substr($row['title'],0,60);?>....</div>
	  <?php // echo $row['message']; ?>	  </td>
	   <td><div align="center" class="bodytext"> <?php echo $row['industry'];?><br /></div>
	   
 
    <td>
	<div class="bodytext">
	  <div align="center"><b>Status :</b> 
	        <?php if($status==0){ ?>
	        <font color="#FF0000"><?php echo "Inactive"; ?></font>
	        <?php }else{?>
	        <font color="#336600"><?php echo "Active"; ?></font>
	        <?php } ?>
	      </div>
	</div>
	<br /><br />
	<div align="center">[ <a href="<?php echo basename($_SERVER['PHP_SELF']); ?>?display=Update&amp;id=<?php echo $row['id']; ?>" title="Edit Frame">Edit</a> | <a  href="<?php echo SITE_URL.ADMIN_PATH.basename($_SERVER['PHP_SELF']); ?>?Action=delete&amp;id=<?php echo $row['id']; ?>&user_id=<?php echo $user_id; ?>" title="Delete" onclick="return confirm('Are you sure you want to delete this record?')">Delete</a> ]	  </div>	</td>
  </tr>
    
  <?php
		$chk++;
	
	}
	?>
  <tr>
    <th colspan="6"><table width="100%" border="0" cellpadding="1" cellspacing="3">
      <tr>
        <td width="30%"><?php echo $starting; ?> - <?php echo $ending; ?> out of <?php echo $totalrows; ?></td>
        <td width="70%" align="center"><?php echo $pagination; ?></td>
      </tr>
    </table></th>
  </tr>
    <?php
	}
	else
	{ // no record
	?>
  <tr>
    <td colspan="6"><h4>No Records</h4></td>
  </tr>
  <?php } ?>
</table>
</form>
<?php }?>
<?php include_once("footer.php");?>