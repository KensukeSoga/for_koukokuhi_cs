package jp.co.isid.ham.operationLog.model;

import java.math.BigDecimal;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj28WorkLog;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �ғ����OVO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/05/15 T.Kobayashi)<BR>
 * </P>
 *
 * @author T.Kobayashi
 */
@XmlRootElement(namespace = "http://model.operationLog.ham.isid.co.jp/")
@XmlType(namespace = "http://model.operationLog.ham.isid.co.jp/")
public class FindOperationLogVO extends AbstractModel{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �t�H�[�}�b�g */
    private static final String DATE_PATTERN = "yyyy/MM/dd";

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindOperationLogVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new FindOperationLogVO();
    }

    /**
     * �f�[�^�쐬�������擾���܂�
     * @param val
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {

    	Date dtTmp = new Date();
    	String strTmp = "";

    	if (get(Tbj28WorkLog.CRTDATE) == null) {
    		// null�̏ꍇ
            return null;
    	}

    	strTmp = get(Tbj28WorkLog.CRTDATE).toString();

    	if (strTmp.length() == 10) {
    		// yyyy/MM/dd�^�̏ꍇ(�W�v�Ƀ`�F�b�N����p�^�[��)
    		// �K�؂ȓ��t�^�ɕϊ�����
    	    try {
    	    	dtTmp = (new SimpleDateFormat(DATE_PATTERN)).parse(strTmp);

  		  	} catch (ParseException e) {
  		  		return null;
    		}
    	} else {
    		// ��L�ȊO(�W�v�Ƀ`�F�b�N�Ȃ��p�^�[��)
    		dtTmp = (Date) get(Tbj28WorkLog.CRTDATE);
    	}

        return dtTmp;
    }

    /**
     * �f�[�^�쐬������ݒ肵�܂�
     */
    public void setCRTDATE(Date val) {
        set(Tbj28WorkLog.CRTDATE, val);
    }

    /**
     * �S����ID(ESQID)���擾���܂�
     * @param val
     */
    public String getHAMID() {
        return (String) get(Tbj28WorkLog.HAMID);
    }

    /**
     * �S����ID(ESQID)��ݒ肵�܂�
     */
    public void setHAMID(String val) {
        set(Tbj28WorkLog.HAMID, val);
    }

    /**
     * �S���Җ����擾���܂�
     * @param val
     */
    public String getHAMNM() {
        return (String) get(Tbj28WorkLog.HAMNM);
    }

    /**
     * �S���Җ���ݒ肵�܂�
     */
    public void setHAMNM(String val) {
        set(Tbj28WorkLog.HAMNM, val);
    }

    /**
     * �g�D�R�[�h�i�{���j���擾���܂�
     * @param val
     */
    public String getSIKCDHONB() {
        return (String) get(Tbj28WorkLog.SIKCDHONB);
    }

    /**
     * �g�D�R�[�h�i�{���j��ݒ肵�܂�
     */
    public void setSIKCDHONB(String val) {
        set(Tbj28WorkLog.SIKCDHONB, val);
    }

    /**
     * �{���\�����i�����j���擾���܂�
     * @param val
     */
    public String getSIKNMHONB() {
        return (String) get(Tbj28WorkLog.SIKNMHONB);
    }

    /**
     * �{���\�����i�����j��ݒ肵�܂�
     */
    public void setSIKNMHONB(String val) {
        set(Tbj28WorkLog.SIKNMHONB, val);
    }

    /**
     * �g�D�R�[�h�i�ǁj���擾���܂�
     * @param val
     */
    public String getSIKCDKYK() {
        return (String) get(Tbj28WorkLog.SIKCDKYK);
    }

    /**
     * �g�D�R�[�h�i�ǁj��ݒ肵�܂�
     */
    public void setSIKCDKYK(String val) {
        set(Tbj28WorkLog.SIKCDKYK, val);
    }

    /**
     * �Ǖ\�����i�����j���擾���܂�
     * @param val
     */
    public String getSIKNMKYK() {
        return (String) get(Tbj28WorkLog.SIKNMKYK);
    }

    /**
     * �Ǖ\�����i�����j��ݒ肵�܂�
     */
    public void setSIKNMKYK(String val) {
        set(Tbj28WorkLog.SIKNMKYK, val);
    }

    /**
     * �g�D�R�[�h�i���j���擾���܂�
     * @param val
     */
    public String getSIKCDSITU() {
        return (String) get(Tbj28WorkLog.SIKCDSITU);
    }

    /**
     * �g�D�R�[�h�i���j��ݒ肵�܂�
     */
    public void setSIKCDSITU(String val) {
        set(Tbj28WorkLog.SIKCDSITU, val);
    }

    /**
     * ���\�����i�����j���擾���܂�
     * @param val
     */
    public String getSIKNMSITU() {
        return (String) get(Tbj28WorkLog.SIKNMSITU);
    }

    /**
     * ���\�����i�����j��ݒ肵�܂�
     */
    public void setSIKNMSITU(String val) {
        set(Tbj28WorkLog.SIKNMSITU, val);
    }

    /**
     * �g�D�R�[�h�i���j���擾���܂�
     * @param val
     */
    public String getSIKCDBU() {
        return (String) get(Tbj28WorkLog.SIKCDBU);
    }

    /**
     * �g�D�R�[�h�i���j��ݒ肵�܂�
     */
    public void setSIKCDBU(String val) {
        set(Tbj28WorkLog.SIKCDBU, val);
    }

    /**
     * ���\�����i�����j���擾���܂�
     * @param val
     */
    public String getSIKNMBU() {
        return (String) get(Tbj28WorkLog.SIKNMBU);
    }

    /**
     * ���\�����i�����j��ݒ肵�܂�
     */
    public void setSIKNMBU(String val) {
        set(Tbj28WorkLog.SIKNMBU, val);
    }

    /**
     * �g�D�R�[�h�i�ہj���擾���܂�
     * @param val
     */
    public String getSIKCDKA() {
        return (String) get(Tbj28WorkLog.SIKCDKA);
    }

    /**
     * �g�D�R�[�h�i�ہj��ݒ肵�܂�
     */
    public void setSIKCDKA(String val) {
        set(Tbj28WorkLog.SIKCDKA, val);
    }

    /**
     * �ە\�����i�����j���擾���܂�
     * @param val
     */
    public String getSIKNMKA() {
        return (String) get(Tbj28WorkLog.SIKNMKA);
    }

    /**
     * �ە\�����i�����j��ݒ肵�܂�
     */
    public void setSIKNMKA(String val) {
        set(Tbj28WorkLog.SIKNMKA, val);
    }

    /**
     * ���ID���擾���܂�
     * @param val
     */
    public String getFORMID() {
        return (String) get(Tbj28WorkLog.FORMID);
    }

    /**
     * ���ID��ݒ肵�܂�
     */
    public void setFORMID(String val) {
        set(Tbj28WorkLog.FORMID, val);
    }

    /**
     * ��ʖ����擾���܂�
     * @param val
     */
    public String getFORMNM() {
        return (String) get(Tbj28WorkLog.FORMNM);
    }

    /**
     * ��ʖ���ݒ肵�܂�
     */
    public void setFORMNM(String val) {
        set(Tbj28WorkLog.FORMNM, val);
    }

    /**
     * �@�\ID���擾���܂�
     * @param val
     */
    public String getKNOID() {
        return (String) get(Tbj28WorkLog.KNOID);
    }

    /**
     * �@�\ID��ݒ肵�܂�
     */
    public void setKNOID(String val) {
        set(Tbj28WorkLog.KNOID, val);
    }

    /**
     * �@�\�����擾���܂�
     * @param val
     */
    public String getKNONM() {
        return (String) get(Tbj28WorkLog.KNONM);
    }

    /**
     * �@�\����ݒ肵�܂�
     */
    public void setKNONM(String val) {
        set(Tbj28WorkLog.KNONM, val);
    }

    /**
     * ����ID���擾���܂�
     * @param val
     */
    public String getDSMID() {
        return (String) get(Tbj28WorkLog.DSMID);
    }

    /**
     * ����ID��ݒ肵�܂�
     */
    public void setDSMID(String val) {
        set(Tbj28WorkLog.DSMID, val);
    }

    /**
     * ���얼���擾���܂�
     * @param val
     */
    public String getDSMNM() {
        return (String) get(Tbj28WorkLog.DSMNM);
    }

    /**
     * ���얼��ݒ肵�܂�
     */
    public void setDSMNM(String val) {
        set(Tbj28WorkLog.DSMNM, val);
    }

    /**
     * �g�D��(�ǁ{���{���{��)���擾���܂�
     * @param val
     */
    public String getSOSHIKIFULLNM() {
        return (String) get("SOSHIKI_FULLNM");
    }

    /**
     * �g�D��(�ǁ{���{���{��)��ݒ肵�܂�
     */
    public void setSOSHIKIFULLNM(String val) {
        set("SOSHIKI_FULLNM", val);
    }

    /**
     * �������擾���܂�
     * @param val
     */
    public BigDecimal getCOUNT() {
        return (BigDecimal) get("LOG_COUNT");
    }

    /**
     * ������ݒ肵�܂�
     */
    public void setCOUNT(BigDecimal val) {
        set("LOG_COUNT", val);
    }
}
