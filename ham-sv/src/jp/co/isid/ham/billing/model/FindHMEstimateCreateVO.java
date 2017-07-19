package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj07EstimateCreate;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HM���ψČ�CR�����擾VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHMEstimateCreateVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindHMEstimateCreateVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     * @return �V�K�C���X�^���X
     */
    @Override
    public Object newInstance() {
        return new FindHMEstimateCreateVO();
    }

    /**
     * ���ϖ��׊Ǘ�NO���擾����
     * @return BigDecimal ���ϖ��׊Ǘ�NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTDETAILSEQNO() {
        return (BigDecimal) get(Tbj07EstimateCreate.ESTDETAILSEQNO);
    }

    /**
     * ���ϖ��׊Ǘ�NO��ݒ肷��
     * @param val BigDecimal ���ϖ��׊Ǘ�NO
     */
    public void setESTDETAILSEQNO(BigDecimal val) {
        set(Tbj07EstimateCreate.ESTDETAILSEQNO, val);
    }

    /**
     * �d�ʎԎ�R�[�h���擾����
     * @return String �d�ʎԎ�R�[�h
     */
    public String getDCARCD() {
        return (String) get(Tbj07EstimateCreate.DCARCD);
    }

    /**
     * �d�ʎԎ�R�[�h��ݒ肷��
     * @param val String �d�ʎԎ�R�[�h
     */
    public void setDCARCD(String val) {
        set(Tbj07EstimateCreate.DCARCD, val);
    }

    /**
     * �t�F�C�Y���擾����
     * @return BigDecimal �t�F�C�Y
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj07EstimateCreate.PHASE);
    }

    /**
     * �t�F�C�Y��ݒ肷��
     * @param val BigDecimal �t�F�C�Y
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj07EstimateCreate.PHASE, val);
    }

    /**
     * �N�����擾����
     * @return Date �N��
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRDATE() {
        return (Date) get(Tbj07EstimateCreate.CRDATE);
    }

    /**
     * �N����ݒ肷��
     * @param val Date �N��
     */
    public void setCRDATE(Date val) {
        set(Tbj07EstimateCreate.CRDATE, val);
    }

    /**
     * �����Ǘ�NO���擾����
     * @return BigDecimal �����Ǘ�NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSEQUENCENO() {
        return (BigDecimal) get(Tbj07EstimateCreate.SEQUENCENO);
    }

    /**
     * �����Ǘ�NO��ݒ肷��
     * @param val BigDecimal �����Ǘ�NO
     */
    public void setSEQUENCENO(BigDecimal val) {
        set(Tbj07EstimateCreate.SEQUENCENO, val);
    }

    /**
     * ��ʔ��f�t���O���擾����
     * @return String ��ʔ��f�t���O
     */
    public String getCLASSDIV() {
        return (String) get(Tbj07EstimateCreate.CLASSDIV);
    }

    /**
     * ��ʔ��f�t���O��ݒ肷��
     * @param val String ��ʔ��f�t���O
     */
    public void setCLASSDIV(String val) {
        set(Tbj07EstimateCreate.CLASSDIV, val);
    }

    /**
     * �\�[�g�����擾����
     * @return BigDecimal �\�[�g��
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Tbj07EstimateCreate.SORTNO);
    }

    /**
     * �\�[�g����ݒ肷��
     * @param val BigDecimal �\�[�g��
     */
    public void setSORTNO(BigDecimal val) {
        set(Tbj07EstimateCreate.SORTNO, val);
    }

    /**
     * �\�Z���ރR�[�h���擾����
     * @return String �\�Z���ރR�[�h
     */
    public String getCLASSCD() {
        return (String) get(Tbj07EstimateCreate.CLASSCD);
    }

    /**
     * �\�Z���ރR�[�h��ݒ肷��
     * @param val String �\�Z���ރR�[�h
     */
    public void setCLASSCD(String val) {
        set(Tbj07EstimateCreate.CLASSCD, val);
    }

    /**
     * �\�Z�\��ڃR�[�h���擾����
     * @return String �\�Z�\��ڃR�[�h
     */
    public String getEXPCD() {
        return (String) get(Tbj07EstimateCreate.EXPCD);
    }

    /**
     * �\�Z�\��ڃR�[�h��ݒ肷��
     * @param val String �\�Z�\��ڃR�[�h
     */
    public void setEXPCD(String val) {
        set(Tbj07EstimateCreate.EXPCD, val);
    }

    /**
     * ��ڂ��擾����
     * @return String ���
     */
    public String getEXPENSE() {
        return (String) get(Tbj07EstimateCreate.EXPENSE);
    }

    /**
     * ��ڂ�ݒ肷��
     * @param val String ���
     */
    public void setEXPENSE(String val) {
        set(Tbj07EstimateCreate.EXPENSE, val);
    }

    /**
     * �ڍׂ��擾����
     * @return String �ڍ�
     */
    public String getDETAIL() {
        return (String) get(Tbj07EstimateCreate.DETAIL);
    }

    /**
     * �ڍׂ�ݒ肷��
     * @param val String �ڍ�
     */
    public void setDETAIL(String val) {
        set(Tbj07EstimateCreate.DETAIL, val);
    }

    /**
     * ���ԊJ�n���擾����
     * @return Date ���ԊJ�n
     */
    @XmlElement(required = true, nillable = true)
    public Date getKIKANS() {
        return (Date) get(Tbj07EstimateCreate.KIKANS);
    }

    /**
     * ���ԊJ�n��ݒ肷��
     * @param val Date ���ԊJ�n
     */
    public void setKIKANS(Date val) {
        set(Tbj07EstimateCreate.KIKANS, val);
    }

    /**
     * ���ԏI�����擾����
     * @return Date ���ԏI��
     */
    @XmlElement(required = true, nillable = true)
    public Date getKIKANE() {
        return (Date) get(Tbj07EstimateCreate.KIKANE);
    }

    /**
     * ���ԏI����ݒ肷��
     * @param val Date ���ԏI��
     */
    public void setKIKANE(Date val) {
        set(Tbj07EstimateCreate.KIKANE, val);
    }

    /**
     * �_��J�n�N�������擾����
     * @return Date �_��J�n�N����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCONTRACTDATE() {
        return (Date) get(Tbj07EstimateCreate.CONTRACTDATE);
    }

    /**
     * �_��J�n�N������ݒ肷��
     * @param val Date �_��J�n�N����
     */
    public void setCONTRACTDATE(Date val) {
        set(Tbj07EstimateCreate.CONTRACTDATE, val);
    }

    /**
     * �_�����(����)���擾����
     * @return String �_�����(����)
     */
    public String getCONTRACTTERM() {
        return (String) get(Tbj07EstimateCreate.CONTRACTTERM);
    }

    /**
     * �_�����(����)��ݒ肷��
     * @param val String �_�����(����)
     */
    public void setCONTRACTTERM(String val) {
        set(Tbj07EstimateCreate.CONTRACTTERM, val);
    }

    /**
     * ��������擾����
     * @return String ������
     */
    public String getSEIKYU() {
        return (String) get(Tbj07EstimateCreate.SEIKYU);
    }

    /**
     * �������ݒ肷��
     * @param val String ������
     */
    public void setSEIKYU(String val) {
        set(Tbj07EstimateCreate.SEIKYU, val);
    }

    /**
     * ��NO���擾����
     * @return String ��NO
     */
    public String getORDERNO() {
        return (String) get(Tbj07EstimateCreate.ORDERNO);
    }

    /**
     * ��NO��ݒ肷��
     * @param val String ��NO
     */
    public void setORDERNO(String val) {
        set(Tbj07EstimateCreate.ORDERNO, val);
    }

    /**
     * �x������擾����
     * @return String �x����
     */
    public String getPAY() {
        return (String) get(Tbj07EstimateCreate.PAY);
    }

    /**
     * �x�����ݒ肷��
     * @param val String �x����
     */
    public void setPAY(String val) {
        set(Tbj07EstimateCreate.PAY, val);
    }

    /**
     * �S���҂��擾����
     * @return String �S����
     */
    public String getUSERNAME() {
        return (String) get(Tbj07EstimateCreate.USERNAME);
    }

    /**
     * �S���҂�ݒ肷��
     * @param val String �S����
     */
    public void setUSERNAME(String val) {
        set(Tbj07EstimateCreate.USERNAME, val);
    }

    /**
     * ����z���擾����
     * @return BigDecimal ����z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGETMONEY() {
        return (BigDecimal) get(Tbj07EstimateCreate.GETMONEY);
    }

    /**
     * ����z��ݒ肷��
     * @param val BigDecimal ����z
     */
    public void setGETMONEY(BigDecimal val) {
        set(Tbj07EstimateCreate.GETMONEY, val);
    }

    /**
     * ����z�m�F���擾����
     * @return String ����z�m�F
     */
    public String getGETCONF() {
        return (String) get(Tbj07EstimateCreate.GETCONF);
    }

    /**
     * ����z�m�F��ݒ肷��
     * @param val String ����z�m�F
     */
    public void setGETCONF(String val) {
        set(Tbj07EstimateCreate.GETCONF, val);
    }

    /**
     * �����z���擾����
     * @return BigDecimal �����z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPAYMONEY() {
        return (BigDecimal) get(Tbj07EstimateCreate.PAYMONEY);
    }

    /**
     * �����z��ݒ肷��
     * @param val BigDecimal �����z
     */
    public void setPAYMONEY(BigDecimal val) {
        set(Tbj07EstimateCreate.PAYMONEY, val);
    }

    /**
     * �����z�m�F���擾����
     * @return String �����z�m�F
     */
    public String getPAYCONF() {
        return (String) get(Tbj07EstimateCreate.PAYCONF);
    }

    /**
     * �����z�m�F��ݒ肷��
     * @param val String �����z�m�F
     */
    public void setPAYCONF(String val) {
        set(Tbj07EstimateCreate.PAYCONF, val);
    }

    /**
     * ���ϋ��z���擾����
     * @return BigDecimal ���ϋ��z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTMONEY() {
        return (BigDecimal) get(Tbj07EstimateCreate.ESTMONEY);
    }

    /**
     * ���ϋ��z��ݒ肷��
     * @param val BigDecimal ���ϋ��z
     */
    public void setESTMONEY(BigDecimal val) {
        set(Tbj07EstimateCreate.ESTMONEY, val);
    }

    /**
     * �������z���擾����
     * @return BigDecimal �������z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCLMMONEY() {
        return (BigDecimal) get(Tbj07EstimateCreate.CLMMONEY);
    }

    /**
     * �������z��ݒ肷��
     * @param val BigDecimal �������z
     */
    public void setCLMMONEY(BigDecimal val) {
        set(Tbj07EstimateCreate.CLMMONEY, val);
    }

    /**
     * �x����[�i�����擾����
     * @return Date �x����[�i��
     */
    @XmlElement(required = true, nillable = true)
    public Date getDELIVERDAY() {
        return (Date) get(Tbj07EstimateCreate.DELIVERDAY);
    }

    /**
     * �x����[�i����ݒ肷��
     * @param val Date �x����[�i��
     */
    public void setDELIVERDAY(Date val) {
        set(Tbj07EstimateCreate.DELIVERDAY, val);
    }

    /**
     * �ݒ茎���擾����
     * @return Date �ݒ茎
     */
    @XmlElement(required = true, nillable = true)
    public Date getSETMONTH() {
        return (Date) get(Tbj07EstimateCreate.SETMONTH);
    }

    /**
     * �ݒ茎��ݒ肷��
     * @param val Date �ݒ茎
     */
    public void setSETMONTH(Date val) {
        set(Tbj07EstimateCreate.SETMONTH, val);
    }

    /**
     * �敪�R�[�h���擾����
     * @return String �敪�R�[�h
     */
    public String getDIVCD() {
        return (String) get(Tbj07EstimateCreate.DIVCD);
    }

    /**
     * �敪�R�[�h��ݒ肷��
     * @param val String �敪�R�[�h
     */
    public void setDIVCD(String val) {
        set(Tbj07EstimateCreate.DIVCD, val);
    }

    /**
     * �O���[�v�R�[�h���擾����
     * @return BigDecimal �O���[�v�R�[�h
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGROUPCD() {
        return (BigDecimal) get(Tbj07EstimateCreate.GROUPCD);
    }

    /**
     * �O���[�v�R�[�h��ݒ肷��
     * @param val BigDecimal �O���[�v�R�[�h
     */
    public void setGROUPCD(BigDecimal val) {
        set(Tbj07EstimateCreate.GROUPCD, val);
    }

    /**
     * �ݒ�ǃi���o�[���擾����
     * @return BigDecimal �ݒ�ǃi���o�[
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSTKYKNO() {
        return (BigDecimal) get(Tbj07EstimateCreate.STKYKNO);
    }

    /**
     * �ݒ�ǃi���o�[��ݒ肷��
     * @param val BigDecimal �ݒ�ǃi���o�[
     */
    public void setSTKYKNO(BigDecimal val) {
        set(Tbj07EstimateCreate.STKYKNO, val);
    }

    /**
     * �c���`�F�b�N���擾����
     * @return String �c���`�F�b�N
     */
    public String getEGTYKFLG() {
        return (String) get(Tbj07EstimateCreate.EGTYKFLG);
    }

    /**
     * �c���`�F�b�N��ݒ肷��
     * @param val String �c���`�F�b�N
     */
    public void setEGTYKFLG(String val) {
        set(Tbj07EstimateCreate.EGTYKFLG, val);
    }

    /**
     * ���͒S���R�[�h���擾����
     * @return BigDecimal ���͒S���R�[�h
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getINPUTTNTCD() {
        return (BigDecimal) get(Tbj07EstimateCreate.INPUTTNTCD);
    }

    /**
     * ���͒S���R�[�h��ݒ肷��
     * @param val BigDecimal ���͒S���R�[�h
     */
    public void setINPUTTNTCD(BigDecimal val) {
        set(Tbj07EstimateCreate.INPUTTNTCD, val);
    }

    /**
     * ���l���擾����
     * @return String ���l
     */
    public String getNOTE() {
        return (String) get(Tbj07EstimateCreate.NOTE);
    }

    /**
     * ���l��ݒ肷��
     * @param val String ���l
     */
    public void setNOTE(String val) {
        set(Tbj07EstimateCreate.NOTE, val);
    }

    /**
     * �\�Z���ރt���O���擾����
     * @return String �\�Z���ރt���O
     */
    public String getCLASSCDFLG() {
        return (String) get(Tbj07EstimateCreate.CLASSCDFLG);
    }

    /**
     * �\�Z���ރt���O��ݒ肷��
     * @param val String �\�Z���ރt���O
     */
    public void setCLASSCDFLG(String val) {
        set(Tbj07EstimateCreate.CLASSCDFLG, val);
    }

    /**
     * �\�Z�\��ڃt���O���擾����
     * @return String �\�Z�\��ڃt���O
     */
    public String getEXPCDFLG() {
        return (String) get(Tbj07EstimateCreate.EXPCDFLG);
    }

    /**
     * �\�Z�\��ڃt���O��ݒ肷��
     * @param val String �\�Z�\��ڃt���O
     */
    public void setEXPCDFLG(String val) {
        set(Tbj07EstimateCreate.EXPCDFLG, val);
    }

    /**
     * ��ڃt���O���擾����
     * @return String ��ڃt���O
     */
    public String getEXPENSEFLG() {
        return (String) get(Tbj07EstimateCreate.EXPENSEFLG);
    }

    /**
     * ��ڃt���O��ݒ肷��
     * @param val String ��ڃt���O
     */
    public void setEXPENSEFLG(String val) {
        set(Tbj07EstimateCreate.EXPENSEFLG, val);
    }

    /**
     * �ڍ׃t���O���擾����
     * @return String �ڍ׃t���O
     */
    public String getDETAILFLG() {
        return (String) get(Tbj07EstimateCreate.DETAILFLG);
    }

    /**
     * �ڍ׃t���O��ݒ肷��
     * @param val String �ڍ׃t���O
     */
    public void setDETAILFLG(String val) {
        set(Tbj07EstimateCreate.DETAILFLG, val);
    }

    /**
     * ���ԊJ�n�t���O���擾����
     * @return String ���ԊJ�n�t���O
     */
    public String getKIKANSFLG() {
        return (String) get(Tbj07EstimateCreate.KIKANSFLG);
    }

    /**
     * ���ԊJ�n�t���O��ݒ肷��
     * @param val String ���ԊJ�n�t���O
     */
    public void setKIKANSFLG(String val) {
        set(Tbj07EstimateCreate.KIKANSFLG, val);
    }

    /**
     * ���ԏI���t���O���擾����
     * @return String ���ԏI���t���O
     */
    public String getKIKANEFLG() {
        return (String) get(Tbj07EstimateCreate.KIKANEFLG);
    }

    /**
     * ���ԏI���t���O��ݒ肷��
     * @param val String ���ԏI���t���O
     */
    public void setKIKANEFLG(String val) {
        set(Tbj07EstimateCreate.KIKANEFLG, val);
    }

    /**
     * �_��J�n�N�����t���O���擾����
     * @return String �_��J�n�N�����t���O
     */
    public String getCONTRACTDATEFLG() {
        return (String) get(Tbj07EstimateCreate.CONTRACTDATEFLG);
    }

    /**
     * �_��J�n�N�����t���O��ݒ肷��
     * @param val String �_��J�n�N�����t���O
     */
    public void setCONTRACTDATEFLG(String val) {
        set(Tbj07EstimateCreate.CONTRACTDATEFLG, val);
    }

    /**
     * �_�����(����)�t���O���擾����
     * @return String �_�����(����)�t���O
     */
    public String getCONTRACTTERMFLG() {
        return (String) get(Tbj07EstimateCreate.CONTRACTTERMFLG);
    }

    /**
     * �_�����(����)�t���O��ݒ肷��
     * @param val String �_�����(����)�t���O
     */
    public void setCONTRACTTERMFLG(String val) {
        set(Tbj07EstimateCreate.CONTRACTTERMFLG, val);
    }

    /**
     * ������t���O���擾����
     * @return String ������t���O
     */
    public String getSEIKYUFLG() {
        return (String) get(Tbj07EstimateCreate.SEIKYUFLG);
    }

    /**
     * ������t���O��ݒ肷��
     * @param val String ������t���O
     */
    public void setSEIKYUFLG(String val) {
        set(Tbj07EstimateCreate.SEIKYUFLG, val);
    }

    /**
     * ��NO�t���O���擾����
     * @return String ��NO�t���O
     */
    public String getORDERNOFLG() {
        return (String) get(Tbj07EstimateCreate.ORDERNOFLG);
    }

    /**
     * ��NO�t���O��ݒ肷��
     * @param val String ��NO�t���O
     */
    public void setORDERNOFLG(String val) {
        set(Tbj07EstimateCreate.ORDERNOFLG, val);
    }

    /**
     * �x����t���O���擾����
     * @return String �x����t���O
     */
    public String getPAYFLG() {
        return (String) get(Tbj07EstimateCreate.PAYFLG);
    }

    /**
     * �x����t���O��ݒ肷��
     * @param val String �x����t���O
     */
    public void setPAYFLG(String val) {
        set(Tbj07EstimateCreate.PAYFLG, val);
    }

    /**
     * �S���҃t���O���擾����
     * @return String �S���҃t���O
     */
    public String getUSERNAMEFLG() {
        return (String) get(Tbj07EstimateCreate.USERNAMEFLG);
    }

    /**
     * �S���҃t���O��ݒ肷��
     * @param val String �S���҃t���O
     */
    public void setUSERNAMEFLG(String val) {
        set(Tbj07EstimateCreate.USERNAMEFLG, val);
    }

    /**
     * ����z�t���O���擾����
     * @return String ����z�t���O
     */
    public String getGETMONEYFLG() {
        return (String) get(Tbj07EstimateCreate.GETMONEYFLG);
    }

    /**
     * ����z�t���O��ݒ肷��
     * @param val String ����z�t���O
     */
    public void setGETMONEYFLG(String val) {
        set(Tbj07EstimateCreate.GETMONEYFLG, val);
    }

    /**
     * �����z�t���O���擾����
     * @return String �����z�t���O
     */
    public String getPAYMONEYFLG() {
        return (String) get(Tbj07EstimateCreate.PAYMONEYFLG);
    }

    /**
     * �����z�t���O��ݒ肷��
     * @param val String �����z�t���O
     */
    public void setPAYMONEYFLG(String val) {
        set(Tbj07EstimateCreate.PAYMONEYFLG, val);
    }

    /**
     * ���ϋ��z�t���O���擾����
     * @return String ���ϋ��z�t���O
     */
    public String getESTMONEYFLG() {
        return (String) get(Tbj07EstimateCreate.ESTMONEYFLG);
    }

    /**
     * ���ϋ��z�t���O��ݒ肷��
     * @param val String ���ϋ��z�t���O
     */
    public void setESTMONEYFLG(String val) {
        set(Tbj07EstimateCreate.ESTMONEYFLG, val);
    }

    /**
     * �������z�t���O���擾����
     * @return String �������z�t���O
     */
    public String getCLMMONEYFLG() {
        return (String) get(Tbj07EstimateCreate.CLMMONEYFLG);
    }

    /**
     * �������z�t���O��ݒ肷��
     * @param val String �������z�t���O
     */
    public void setCLMMONEYFLG(String val) {
        set(Tbj07EstimateCreate.CLMMONEYFLG, val);
    }

    /**
     * �x����[�i���t���O���擾����
     * @return String �x����[�i���t���O
     */
    public String getDELIVERDAYFLG() {
        return (String) get(Tbj07EstimateCreate.DELIVERDAYFLG);
    }

    /**
     * �x����[�i���t���O��ݒ肷��
     * @param val String �x����[�i���t���O
     */
    public void setDELIVERDAYFLG(String val) {
        set(Tbj07EstimateCreate.DELIVERDAYFLG, val);
    }

    /**
     * �ݒ茎�t���O���擾����
     * @return String �ݒ茎�t���O
     */
    public String getSETMONTHFLG() {
        return (String) get(Tbj07EstimateCreate.SETMONTHFLG);
    }

    /**
     * �ݒ茎�t���O��ݒ肷��
     * @param val String �ݒ茎�t���O
     */
    public void setSETMONTHFLG(String val) {
        set(Tbj07EstimateCreate.SETMONTHFLG, val);
    }

    /**
     * �敪�t���O���擾����
     * @return String �敪�t���O
     */
    public String getDIVISIONFLG() {
        return (String) get(Tbj07EstimateCreate.DIVISIONFLG);
    }

    /**
     * �敪�t���O��ݒ肷��
     * @param val String �敪�t���O
     */
    public void setDIVISIONFLG(String val) {
        set(Tbj07EstimateCreate.DIVISIONFLG, val);
    }

    /**
     * �O���[�v�R�[�h�t���O���擾����
     * @return String �O���[�v�R�[�h�t���O
     */
    public String getGROUPCDFLG() {
        return (String) get(Tbj07EstimateCreate.GROUPCDFLG);
    }

    /**
     * �O���[�v�R�[�h�t���O��ݒ肷��
     * @param val String �O���[�v�R�[�h�t���O
     */
    public void setGROUPCDFLG(String val) {
        set(Tbj07EstimateCreate.GROUPCDFLG, val);
    }

    /**
     * �ݒ�ǃi���o�[�t���O���擾����
     * @return String �ݒ�ǃi���o�[�t���O
     */
    public String getSTKYKNOFLG() {
        return (String) get(Tbj07EstimateCreate.STKYKNOFLG);
    }

    /**
     * �ݒ�ǃi���o�[�t���O��ݒ肷��
     * @param val String �ݒ�ǃi���o�[�t���O
     */
    public void setSTKYKNOFLG(String val) {
        set(Tbj07EstimateCreate.STKYKNOFLG, val);
    }

    /**
     * ���͒S���R�[�h�t���O���擾����
     * @return String ���͒S���R�[�h�t���O
     */
    public String getINPUTTNTCDFLG() {
        return (String) get(Tbj07EstimateCreate.INPUTTNTCDFLG);
    }

    /**
     * ���͒S���R�[�h�t���O��ݒ肷��
     * @param val String ���͒S���R�[�h�t���O
     */
    public void setINPUTTNTCDFLG(String val) {
        set(Tbj07EstimateCreate.INPUTTNTCDFLG, val);
    }

    /**
     * ���l�t���O���擾����
     * @return String ���l�t���O
     */
    public String getNOTEFLG() {
        return (String) get(Tbj07EstimateCreate.NOTEFLG);
    }

    /**
     * ���l�t���O��ݒ肷��
     * @param val String ���l�t���O
     */
    public void setNOTEFLG(String val) {
        set(Tbj07EstimateCreate.NOTEFLG, val);
    }

    /**
     * �f�[�^�쐬�������擾����
     * @return Date �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj07EstimateCreate.CRTDATE);
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     * @param val Date �f�[�^�쐬����
     */
    public void setCRTDATE(Date val) {
        set(Tbj07EstimateCreate.CRTDATE, val);
    }

    /**
     * �f�[�^�쐬�҂��擾����
     * @return String �f�[�^�쐬��
     */
    public String getCRTNM() {
        return (String) get(Tbj07EstimateCreate.CRTNM);
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     * @param val String �f�[�^�쐬��
     */
    public void setCRTNM(String val) {
        set(Tbj07EstimateCreate.CRTNM, val);
    }

    /**
     * �쐬�v���O�������擾����
     * @return String �쐬�v���O����
     */
    public String getCRTAPL() {
        return (String) get(Tbj07EstimateCreate.CRTAPL);
    }

    /**
     * �쐬�v���O������ݒ肷��
     * @param val String �쐬�v���O����
     */
    public void setCRTAPL(String val) {
        set(Tbj07EstimateCreate.CRTAPL, val);
    }

    /**
     * �쐬�S����ID���擾����
     * @return String �쐬�S����ID
     */
    public String getCRTID() {
        return (String) get(Tbj07EstimateCreate.CRTID);
    }

    /**
     * �쐬�S����ID��ݒ肷��
     * @param val String �쐬�S����ID
     */
    public void setCRTID(String val) {
        set(Tbj07EstimateCreate.CRTID, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     * @return Date �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj07EstimateCreate.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     * @param val Date �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Tbj07EstimateCreate.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     * @return String �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Tbj07EstimateCreate.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     * @param val String �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Tbj07EstimateCreate.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     * @return String �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Tbj07EstimateCreate.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     * @param val String �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Tbj07EstimateCreate.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     * @return String �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Tbj07EstimateCreate.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     * @param val String �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Tbj07EstimateCreate.UPDID, val);
    }

    /**
     * �����f�[�^�擾�������擾����
     * @return Date �����f�[�^�擾����
     */
    @XmlElement(required = true, nillable = true)
    public Date getGETTIME() {
        return (Date) get(Tbj07EstimateCreate.GETTIME);
    }

    /**
     * �����f�[�^�擾������ݒ肷��
     * @param val Date �����f�[�^�擾����
     */
    public void setGETTIME(Date val) {
        set(Tbj07EstimateCreate.GETTIME, val);
    }

    /**
     * �^�C���X�^���v(����)���擾����
     * @return Date �^�C���X�^���v(����)
     */
    @XmlElement(required = true, nillable = true)
    public Date getTIMSTMPSS() {
        return (Date) get(Tbj07EstimateCreate.TIMSTMPSS);
    }

    /**
     * �^�C���X�^���v(����)��ݒ肷��
     * @param val Date �^�C���X�^���v(����)
     */
    public void setTIMSTMPSS(Date val) {
        set(Tbj07EstimateCreate.TIMSTMPSS, val);
    }

    /**
     * �X�V�v���O����(����)���擾����
     * @return String �X�V�v���O����(����)
     */
    public String getUPDAPLSS() {
        return (String) get(Tbj07EstimateCreate.UPDAPLSS);
    }

    /**
     * �X�V�v���O����(����)��ݒ肷��
     * @param val String �X�V�v���O����(����)
     */
    public void setUPDAPLSS(String val) {
        set(Tbj07EstimateCreate.UPDAPLSS, val);
    }

    /**
     * �X�V�S����ID(����)���擾����
     * @return String �X�V�S����ID(����)
     */
    public String getUPDIDSS() {
        return (String) get(Tbj07EstimateCreate.UPDIDSS);
    }

    /**
     * �X�V�S����ID(����)��ݒ肷��
     * @param val String �X�V�S����ID(����)
     */
    public void setUPDIDSS(String val) {
        set(Tbj07EstimateCreate.UPDIDSS, val);
    }

}
