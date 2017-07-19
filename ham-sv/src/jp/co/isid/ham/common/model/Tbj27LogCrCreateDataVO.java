package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj27LogCrCreateData;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * CR�����Ǘ��ύX���OVO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj27LogCrCreateDataVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj27LogCrCreateDataVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Tbj27LogCrCreateDataVO();
    }

    /**
     * �d�ʎԎ�R�[�h���擾����
     *
     * @return �d�ʎԎ�R�[�h
     */
    public String getDCARCD() {
        return (String) get(Tbj27LogCrCreateData.DCARCD);
    }

    /**
     * �d�ʎԎ�R�[�h��ݒ肷��
     *
     * @param val �d�ʎԎ�R�[�h
     */
    public void setDCARCD(String val) {
        set(Tbj27LogCrCreateData.DCARCD, val);
    }

    /**
     * �t�F�C�Y���擾����
     *
     * @return �t�F�C�Y
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj27LogCrCreateData.PHASE);
    }

    /**
     * �t�F�C�Y��ݒ肷��
     *
     * @param val �t�F�C�Y
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj27LogCrCreateData.PHASE, val);
    }

    /**
     * �N�����擾����
     *
     * @return �N��
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRDATE() {
        return (Date) get(Tbj27LogCrCreateData.CRDATE);
    }

    /**
     * �N����ݒ肷��
     *
     * @param val �N��
     */
    public void setCRDATE(Date val) {
        set(Tbj27LogCrCreateData.CRDATE, val);
    }

    /**
     * �����Ǘ�NO���擾����
     *
     * @return �����Ǘ�NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSEQUENCENO() {
        return (BigDecimal) get(Tbj27LogCrCreateData.SEQUENCENO);
    }

    /**
     * �����Ǘ�NO��ݒ肷��
     *
     * @param val �����Ǘ�NO
     */
    public void setSEQUENCENO(BigDecimal val) {
        set(Tbj27LogCrCreateData.SEQUENCENO, val);
    }

    /**
     * ����NO���擾����
     *
     * @return ����NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHISTORYNO() {
        return (BigDecimal) get(Tbj27LogCrCreateData.HISTORYNO);
    }

    /**
     * ����NO��ݒ肷��
     *
     * @param val ����NO
     */
    public void setHISTORYNO(BigDecimal val) {
        set(Tbj27LogCrCreateData.HISTORYNO, val);
    }

    /**
     * �����敪���擾����
     *
     * @return �����敪
     */
    public String getHISTORYKBN() {
        return (String) get(Tbj27LogCrCreateData.HISTORYKBN);
    }

    /**
     * �����敪��ݒ肷��
     *
     * @param val �����敪
     */
    public void setHISTORYKBN(String val) {
        set(Tbj27LogCrCreateData.HISTORYKBN, val);
    }

    /**
     * ��ʔ��f�t���O���擾����
     *
     * @return ��ʔ��f�t���O
     */
    public String getCLASSDIV() {
        return (String) get(Tbj27LogCrCreateData.CLASSDIV);
    }

    /**
     * ��ʔ��f�t���O��ݒ肷��
     *
     * @param val ��ʔ��f�t���O
     */
    public void setCLASSDIV(String val) {
        set(Tbj27LogCrCreateData.CLASSDIV, val);
    }

    /**
     * �\�[�g�����擾����
     *
     * @return �\�[�g��
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Tbj27LogCrCreateData.SORTNO);
    }

    /**
     * �\�[�g����ݒ肷��
     *
     * @param val �\�[�g��
     */
    public void setSORTNO(BigDecimal val) {
        set(Tbj27LogCrCreateData.SORTNO, val);
    }

    /**
     * �\�Z���ރR�[�h���擾����
     *
     * @return �\�Z���ރR�[�h
     */
    public String getCLASSCD() {
        return (String) get(Tbj27LogCrCreateData.CLASSCD);
    }

    /**
     * �\�Z���ރR�[�h��ݒ肷��
     *
     * @param val �\�Z���ރR�[�h
     */
    public void setCLASSCD(String val) {
        set(Tbj27LogCrCreateData.CLASSCD, val);
    }

    /**
     * �\�Z�\��ڃR�[�h���擾����
     *
     * @return �\�Z�\��ڃR�[�h
     */
    public String getEXPCD() {
        return (String) get(Tbj27LogCrCreateData.EXPCD);
    }

    /**
     * �\�Z�\��ڃR�[�h��ݒ肷��
     *
     * @param val �\�Z�\��ڃR�[�h
     */
    public void setEXPCD(String val) {
        set(Tbj27LogCrCreateData.EXPCD, val);
    }

    /**
     * ��ڂ��擾����
     *
     * @return ���
     */
    public String getEXPENSE() {
        return (String) get(Tbj27LogCrCreateData.EXPENSE);
    }

    /**
     * ��ڂ�ݒ肷��
     *
     * @param val ���
     */
    public void setEXPENSE(String val) {
        set(Tbj27LogCrCreateData.EXPENSE, val);
    }

    /**
     * �ڍׂ��擾����
     *
     * @return �ڍ�
     */
    public String getDETAIL() {
        return (String) get(Tbj27LogCrCreateData.DETAIL);
    }

    /**
     * �ڍׂ�ݒ肷��
     *
     * @param val �ڍ�
     */
    public void setDETAIL(String val) {
        set(Tbj27LogCrCreateData.DETAIL, val);
    }

    /**
     * ���ԊJ�n���擾����
     *
     * @return ���ԊJ�n
     */
    @XmlElement(required = true, nillable = true)
    public Date getKIKANS() {
        return (Date) get(Tbj27LogCrCreateData.KIKANS);
    }

    /**
     * ���ԊJ�n��ݒ肷��
     *
     * @param val ���ԊJ�n
     */
    public void setKIKANS(Date val) {
        set(Tbj27LogCrCreateData.KIKANS, val);
    }

    /**
     * ���ԏI�����擾����
     *
     * @return ���ԏI��
     */
    @XmlElement(required = true, nillable = true)
    public Date getKIKANE() {
        return (Date) get(Tbj27LogCrCreateData.KIKANE);
    }

    /**
     * ���ԏI����ݒ肷��
     *
     * @param val ���ԏI��
     */
    public void setKIKANE(Date val) {
        set(Tbj27LogCrCreateData.KIKANE, val);
    }

    /**
     * �_��J�n�N�������擾����
     *
     * @return �_��J�n�N����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCONTRACTDATE() {
        return (Date) get(Tbj27LogCrCreateData.CONTRACTDATE);
    }

    /**
     * �_��J�n�N������ݒ肷��
     *
     * @param val �_��J�n�N����
     */
    public void setCONTRACTDATE(Date val) {
        set(Tbj27LogCrCreateData.CONTRACTDATE, val);
    }

    /**
     * �_�����(����)���擾����
     *
     * @return �_�����(����)
     */
    public String getCONTRACTTERM() {
        return (String) get(Tbj27LogCrCreateData.CONTRACTTERM);
    }

    /**
     * �_�����(����)��ݒ肷��
     *
     * @param val �_�����(����)
     */
    public void setCONTRACTTERM(String val) {
        set(Tbj27LogCrCreateData.CONTRACTTERM, val);
    }

    /**
     * ��������擾����
     *
     * @return ������
     */
    public String getSEIKYU() {
        return (String) get(Tbj27LogCrCreateData.SEIKYU);
    }

    /**
     * �������ݒ肷��
     *
     * @param val ������
     */
    public void setSEIKYU(String val) {
        set(Tbj27LogCrCreateData.SEIKYU, val);
    }

    /**
     * �����������ƃR�[�h���擾����
     *
     * @return �����������ƃR�[�h
     */
    public String getTRTHSKGYCD() {
        return (String) get(Tbj27LogCrCreateData.TRTHSKGYCD);
    }

    /**
     * �����������ƃR�[�h��ݒ肷��
     *
     * @param val �����������ƃR�[�h
     */
    public void setTRTHSKGYCD(String val) {
        set(Tbj27LogCrCreateData.TRTHSKGYCD, val);
    }

    /**
     * ������r�d�p�m�n���擾����
     *
     * @return ������r�d�p�m�n
     */
    public String getTRSEQNO() {
        return (String) get(Tbj27LogCrCreateData.TRSEQNO);
    }

    /**
     * ������r�d�p�m�n��ݒ肷��
     *
     * @param val ������r�d�p�m�n
     */
    public void setTRSEQNO(String val) {
        set(Tbj27LogCrCreateData.TRSEQNO, val);
    }

    /**
     * ��NO���擾����
     *
     * @return ��NO
     */
    public String getORDERNO() {
        return (String) get(Tbj27LogCrCreateData.ORDERNO);
    }

    /**
     * ��NO��ݒ肷��
     *
     * @param val ��NO
     */
    public void setORDERNO(String val) {
        set(Tbj27LogCrCreateData.ORDERNO, val);
    }

    /**
     * �x������擾����
     *
     * @return �x����
     */
    public String getPAY() {
        return (String) get(Tbj27LogCrCreateData.PAY);
    }

    /**
     * �x�����ݒ肷��
     *
     * @param val �x����
     */
    public void setPAY(String val) {
        set(Tbj27LogCrCreateData.PAY, val);
    }

    /**
     * �x���������ƃR�[�h���擾����
     *
     * @return �x���������ƃR�[�h
     */
    public String getHRTHSKGYCD() {
        return (String) get(Tbj27LogCrCreateData.HRTHSKGYCD);
    }

    /**
     * �x���������ƃR�[�h��ݒ肷��
     *
     * @param val �x���������ƃR�[�h
     */
    public void setHRTHSKGYCD(String val) {
        set(Tbj27LogCrCreateData.HRTHSKGYCD, val);
    }

    /**
     * �x����r�d�p�m�n���擾����
     *
     * @return �x����r�d�p�m�n
     */
    public String getHRSEQNO() {
        return (String) get(Tbj27LogCrCreateData.HRSEQNO);
    }

    /**
     * �x����r�d�p�m�n��ݒ肷��
     *
     * @param val �x����r�d�p�m�n
     */
    public void setHRSEQNO(String val) {
        set(Tbj27LogCrCreateData.HRSEQNO, val);
    }

    /**
     * �S���҂��擾����
     *
     * @return �S����
     */
    public String getUSERNAME() {
        return (String) get(Tbj27LogCrCreateData.USERNAME);
    }

    /**
     * �S���҂�ݒ肷��
     *
     * @param val �S����
     */
    public void setUSERNAME(String val) {
        set(Tbj27LogCrCreateData.USERNAME, val);
    }

    /**
     * �����z���擾����
     *
     * @return �����z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGETMONEY() {
        return (BigDecimal) get(Tbj27LogCrCreateData.GETMONEY);
    }

    /**
     * �����z��ݒ肷��
     *
     * @param val �����z
     */
    public void setGETMONEY(BigDecimal val) {
        set(Tbj27LogCrCreateData.GETMONEY, val);
    }

    /**
     * �����z�m�F���擾����
     *
     * @return �����z�m�F
     */
    public String getGETCONF() {
        return (String) get(Tbj27LogCrCreateData.GETCONF);
    }

    /**
     * �����z�m�F��ݒ肷��
     *
     * @param val �����z�m�F
     */
    public void setGETCONF(String val) {
        set(Tbj27LogCrCreateData.GETCONF, val);
    }

    /**
     * �������z���擾����
     *
     * @return �������z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPAYMONEY() {
        return (BigDecimal) get(Tbj27LogCrCreateData.PAYMONEY);
    }

    /**
     * �������z��ݒ肷��
     *
     * @param val �������z
     */
    public void setPAYMONEY(BigDecimal val) {
        set(Tbj27LogCrCreateData.PAYMONEY, val);
    }

    /**
     * �������z�m�F���擾����
     *
     * @return �������z�m�F
     */
    public String getPAYCONF() {
        return (String) get(Tbj27LogCrCreateData.PAYCONF);
    }

    /**
     * �������z�m�F��ݒ肷��
     *
     * @param val �������z�m�F
     */
    public void setPAYCONF(String val) {
        set(Tbj27LogCrCreateData.PAYCONF, val);
    }

    /**
     * ���ϋ��z���擾����
     *
     * @return ���ϋ��z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTMONEY() {
        return (BigDecimal) get(Tbj27LogCrCreateData.ESTMONEY);
    }

    /**
     * ���ϋ��z��ݒ肷��
     *
     * @param val ���ϋ��z
     */
    public void setESTMONEY(BigDecimal val) {
        set(Tbj27LogCrCreateData.ESTMONEY, val);
    }

    /**
     * �������z���擾����
     *
     * @return �������z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCLMMONEY() {
        return (BigDecimal) get(Tbj27LogCrCreateData.CLMMONEY);
    }

    /**
     * �������z��ݒ肷��
     *
     * @param val �������z
     */
    public void setCLMMONEY(BigDecimal val) {
        set(Tbj27LogCrCreateData.CLMMONEY, val);
    }

    /**
     * �x����[�i�����擾����
     *
     * @return �x����[�i��
     */
    @XmlElement(required = true, nillable = true)
    public Date getDELIVERDAY() {
        return (Date) get(Tbj27LogCrCreateData.DELIVERDAY);
    }

    /**
     * �x����[�i����ݒ肷��
     *
     * @param val �x����[�i��
     */
    public void setDELIVERDAY(Date val) {
        set(Tbj27LogCrCreateData.DELIVERDAY, val);
    }

    /**
     * �ݒ茎���擾����
     *
     * @return �ݒ茎
     */
    @XmlElement(required = true, nillable = true)
    public Date getSETMONTH() {
        return (Date) get(Tbj27LogCrCreateData.SETMONTH);
    }

    /**
     * �ݒ茎��ݒ肷��
     *
     * @param val �ݒ茎
     */
    public void setSETMONTH(Date val) {
        set(Tbj27LogCrCreateData.SETMONTH, val);
    }

    /**
     * �敪�R�[�h���擾����
     *
     * @return �敪�R�[�h
     */
    public String getDIVCD() {
        return (String) get(Tbj27LogCrCreateData.DIVCD);
    }

    /**
     * �敪�R�[�h��ݒ肷��
     *
     * @param val �敪�R�[�h
     */
    public void setDIVCD(String val) {
        set(Tbj27LogCrCreateData.DIVCD, val);
    }

    /**
     * �O���[�v�R�[�h���擾����
     *
     * @return �O���[�v�R�[�h
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGROUPCD() {
        return (BigDecimal) get(Tbj27LogCrCreateData.GROUPCD);
    }

    /**
     * �O���[�v�R�[�h��ݒ肷��
     *
     * @param val �O���[�v�R�[�h
     */
    public void setGROUPCD(BigDecimal val) {
        set(Tbj27LogCrCreateData.GROUPCD, val);
    }

    /**
     * �ݒ�ǃi���o�[���擾����
     *
     * @return �ݒ�ǃi���o�[
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSTKYKNO() {
        return (BigDecimal) get(Tbj27LogCrCreateData.STKYKNO);
    }

    /**
     * �ݒ�ǃi���o�[��ݒ肷��
     *
     * @param val �ݒ�ǃi���o�[
     */
    public void setSTKYKNO(BigDecimal val) {
        set(Tbj27LogCrCreateData.STKYKNO, val);
    }

    /**
     * �ݒ�S����ID���擾����
     *
     * @return �ݒ�S����ID
     */
    public String getSTTNTID() {
        return (String) get(Tbj27LogCrCreateData.STTNTID);
    }

    /**
     * �ݒ�S����ID��ݒ肷��
     *
     * @param val �ݒ�S����ID
     */
    public void setSTTNTID(String val) {
        set(Tbj27LogCrCreateData.STTNTID, val);
    }

    /**
     * �ݒ�S���Җ����擾����
     *
     * @return �ݒ�S���Җ�
     */
    public String getSTTNTNM() {
        return (String) get(Tbj27LogCrCreateData.STTNTNM);
    }

    /**
     * �ݒ�S���Җ���ݒ肷��
     *
     * @param val �ݒ�S���Җ�
     */
    public void setSTTNTNM(String val) {
        set(Tbj27LogCrCreateData.STTNTNM, val);
    }

    /**
     * �c���`�F�b�N���擾����
     *
     * @return �c���`�F�b�N
     */
    public String getEGTYKFLG() {
        return (String) get(Tbj27LogCrCreateData.EGTYKFLG);
    }

    /**
     * �c���`�F�b�N��ݒ肷��
     *
     * @param val �c���`�F�b�N
     */
    public void setEGTYKFLG(String val) {
        set(Tbj27LogCrCreateData.EGTYKFLG, val);
    }

    /**
     * ���͒S���R�[�h���擾����
     *
     * @return ���͒S���R�[�h
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getINPUTTNTCD() {
        return (BigDecimal) get(Tbj27LogCrCreateData.INPUTTNTCD);
    }

    /**
     * ���͒S���R�[�h��ݒ肷��
     *
     * @param val ���͒S���R�[�h
     */
    public void setINPUTTNTCD(BigDecimal val) {
        set(Tbj27LogCrCreateData.INPUTTNTCD, val);
    }

    /**
     * CP�S���Җ����擾����
     *
     * @return CP�S���Җ�
     */
    public String getCPTNTNM() {
        return (String) get(Tbj27LogCrCreateData.CPTNTNM);
    }

    /**
     * CP�S���Җ���ݒ肷��
     *
     * @param val CP�S���Җ�
     */
    public void setCPTNTNM(String val) {
        set(Tbj27LogCrCreateData.CPTNTNM, val);
    }

    /**
     * ���l���擾����
     *
     * @return ���l
     */
    public String getNOTE() {
        return (String) get(Tbj27LogCrCreateData.NOTE);
    }

    /**
     * ���l��ݒ肷��
     *
     * @param val ���l
     */
    public void setNOTE(String val) {
        set(Tbj27LogCrCreateData.NOTE, val);
    }

    /**
     * TCKEY���擾����
     *
     * @return TCKEY
     */
    public String getTCKEY() {
        return (String) get(Tbj27LogCrCreateData.TCKEY);
    }

    /**
     * TCKEY��ݒ肷��
     *
     * @param val TCKEY
     */
    public void setTCKEY(String val) {
        set(Tbj27LogCrCreateData.TCKEY, val);
    }

    /**
     * ��T�u�m�n���擾����
     *
     * @return ��T�u�m�n
     */
    public String getTRSUBNO() {
        return (String) get(Tbj27LogCrCreateData.TRSUBNO);
    }

    /**
     * ��T�u�m�n��ݒ肷��
     *
     * @param val ��T�u�m�n
     */
    public void setTRSUBNO(String val) {
        set(Tbj27LogCrCreateData.TRSUBNO, val);
    }

    /**
     * ���T�u�m�n���擾����
     *
     * @return ���T�u�m�n
     */
    public String getHRSUBNO() {
        return (String) get(Tbj27LogCrCreateData.HRSUBNO);
    }

    /**
     * ���T�u�m�n��ݒ肷��
     *
     * @param val ���T�u�m�n
     */
    public void setHRSUBNO(String val) {
        set(Tbj27LogCrCreateData.HRSUBNO, val);
    }

    /**
     * �A�g�X�e�[�^�X���擾����
     *
     * @return �A�g�X�e�[�^�X
     */
    public String getRSTATUS() {
        return (String) get(Tbj27LogCrCreateData.RSTATUS);
    }

    /**
     * �A�g�X�e�[�^�X��ݒ肷��
     *
     * @param val �A�g�X�e�[�^�X
     */
    public void setRSTATUS(String val) {
        set(Tbj27LogCrCreateData.RSTATUS, val);
    }

    /**
     * ���~�敪���擾����
     *
     * @return ���~�敪
     */
    public String getSTPKBN() {
        return (String) get(Tbj27LogCrCreateData.STPKBN);
    }

    /**
     * ���~�敪��ݒ肷��
     *
     * @param val ���~�敪
     */
    public void setSTPKBN(String val) {
        set(Tbj27LogCrCreateData.STPKBN, val);
    }

    /**
     * �d�ʎԎ�R�[�h�t���O���擾����
     *
     * @return �d�ʎԎ�R�[�h�t���O
     */
    public String getDCARCDFLG() {
        return (String) get(Tbj27LogCrCreateData.DCARCDFLG);
    }

    /**
     * �d�ʎԎ�R�[�h�t���O��ݒ肷��
     *
     * @param val �d�ʎԎ�R�[�h�t���O
     */
    public void setDCARCDFLG(String val) {
        set(Tbj27LogCrCreateData.DCARCDFLG, val);
    }

    /**
     * �\�Z���ރt���O���擾����
     *
     * @return �\�Z���ރt���O
     */
    public String getCLASSCDFLG() {
        return (String) get(Tbj27LogCrCreateData.CLASSCDFLG);
    }

    /**
     * �\�Z���ރt���O��ݒ肷��
     *
     * @param val �\�Z���ރt���O
     */
    public void setCLASSCDFLG(String val) {
        set(Tbj27LogCrCreateData.CLASSCDFLG, val);
    }

    /**
     * �\�Z�\��ڃt���O���擾����
     *
     * @return �\�Z�\��ڃt���O
     */
    public String getEXPCDFLG() {
        return (String) get(Tbj27LogCrCreateData.EXPCDFLG);
    }

    /**
     * �\�Z�\��ڃt���O��ݒ肷��
     *
     * @param val �\�Z�\��ڃt���O
     */
    public void setEXPCDFLG(String val) {
        set(Tbj27LogCrCreateData.EXPCDFLG, val);
    }

    /**
     * ��ڃt���O���擾����
     *
     * @return ��ڃt���O
     */
    public String getEXPENSEFLG() {
        return (String) get(Tbj27LogCrCreateData.EXPENSEFLG);
    }

    /**
     * ��ڃt���O��ݒ肷��
     *
     * @param val ��ڃt���O
     */
    public void setEXPENSEFLG(String val) {
        set(Tbj27LogCrCreateData.EXPENSEFLG, val);
    }

    /**
     * �ڍ׃t���O���擾����
     *
     * @return �ڍ׃t���O
     */
    public String getDETAILFLG() {
        return (String) get(Tbj27LogCrCreateData.DETAILFLG);
    }

    /**
     * �ڍ׃t���O��ݒ肷��
     *
     * @param val �ڍ׃t���O
     */
    public void setDETAILFLG(String val) {
        set(Tbj27LogCrCreateData.DETAILFLG, val);
    }

    /**
     * ���ԊJ�n�t���O���擾����
     *
     * @return ���ԊJ�n�t���O
     */
    public String getKIKANSFLG() {
        return (String) get(Tbj27LogCrCreateData.KIKANSFLG);
    }

    /**
     * ���ԊJ�n�t���O��ݒ肷��
     *
     * @param val ���ԊJ�n�t���O
     */
    public void setKIKANSFLG(String val) {
        set(Tbj27LogCrCreateData.KIKANSFLG, val);
    }

    /**
     * ���ԏI���t���O���擾����
     *
     * @return ���ԏI���t���O
     */
    public String getKIKANEFLG() {
        return (String) get(Tbj27LogCrCreateData.KIKANEFLG);
    }

    /**
     * ���ԏI���t���O��ݒ肷��
     *
     * @param val ���ԏI���t���O
     */
    public void setKIKANEFLG(String val) {
        set(Tbj27LogCrCreateData.KIKANEFLG, val);
    }

    /**
     * �_��J�n�N�����t���O���擾����
     *
     * @return �_��J�n�N�����t���O
     */
    public String getCONTRACTDATEFLG() {
        return (String) get(Tbj27LogCrCreateData.CONTRACTDATEFLG);
    }

    /**
     * �_��J�n�N�����t���O��ݒ肷��
     *
     * @param val �_��J�n�N�����t���O
     */
    public void setCONTRACTDATEFLG(String val) {
        set(Tbj27LogCrCreateData.CONTRACTDATEFLG, val);
    }

    /**
     * �_�����(����)�t���O���擾����
     *
     * @return �_�����(����)�t���O
     */
    public String getCONTRACTTERMFLG() {
        return (String) get(Tbj27LogCrCreateData.CONTRACTTERMFLG);
    }

    /**
     * �_�����(����)�t���O��ݒ肷��
     *
     * @param val �_�����(����)�t���O
     */
    public void setCONTRACTTERMFLG(String val) {
        set(Tbj27LogCrCreateData.CONTRACTTERMFLG, val);
    }

    /**
     * ������t���O���擾����
     *
     * @return ������t���O
     */
    public String getSEIKYUFLG() {
        return (String) get(Tbj27LogCrCreateData.SEIKYUFLG);
    }

    /**
     * ������t���O��ݒ肷��
     *
     * @param val ������t���O
     */
    public void setSEIKYUFLG(String val) {
        set(Tbj27LogCrCreateData.SEIKYUFLG, val);
    }

    /**
     * ��NO�t���O���擾����
     *
     * @return ��NO�t���O
     */
    public String getORDERNOFLG() {
        return (String) get(Tbj27LogCrCreateData.ORDERNOFLG);
    }

    /**
     * ��NO�t���O��ݒ肷��
     *
     * @param val ��NO�t���O
     */
    public void setORDERNOFLG(String val) {
        set(Tbj27LogCrCreateData.ORDERNOFLG, val);
    }

    /**
     * �x����t���O���擾����
     *
     * @return �x����t���O
     */
    public String getPAYFLG() {
        return (String) get(Tbj27LogCrCreateData.PAYFLG);
    }

    /**
     * �x����t���O��ݒ肷��
     *
     * @param val �x����t���O
     */
    public void setPAYFLG(String val) {
        set(Tbj27LogCrCreateData.PAYFLG, val);
    }

    /**
     * �S���҃t���O���擾����
     *
     * @return �S���҃t���O
     */
    public String getUSERNAMEFLG() {
        return (String) get(Tbj27LogCrCreateData.USERNAMEFLG);
    }

    /**
     * �S���҃t���O��ݒ肷��
     *
     * @param val �S���҃t���O
     */
    public void setUSERNAMEFLG(String val) {
        set(Tbj27LogCrCreateData.USERNAMEFLG, val);
    }

    /**
     * �����z�t���O���擾����
     *
     * @return �����z�t���O
     */
    public String getGETMONEYFLG() {
        return (String) get(Tbj27LogCrCreateData.GETMONEYFLG);
    }

    /**
     * �����z�t���O��ݒ肷��
     *
     * @param val �����z�t���O
     */
    public void setGETMONEYFLG(String val) {
        set(Tbj27LogCrCreateData.GETMONEYFLG, val);
    }

    /**
     * �����z�m�F�t���O���擾����
     *
     * @return �����z�m�F�t���O
     */
    public String getGETCONFIRMFLG() {
        return (String) get(Tbj27LogCrCreateData.GETCONFIRMFLG);
    }

    /**
     * �����z�m�F�t���O��ݒ肷��
     *
     * @param val �����z�m�F�t���O
     */
    public void setGETCONFIRMFLG(String val) {
        set(Tbj27LogCrCreateData.GETCONFIRMFLG, val);
    }

    /**
     * �������z�t���O���擾����
     *
     * @return �������z�t���O
     */
    public String getPAYMONEYFLG() {
        return (String) get(Tbj27LogCrCreateData.PAYMONEYFLG);
    }

    /**
     * �������z�t���O��ݒ肷��
     *
     * @param val �������z�t���O
     */
    public void setPAYMONEYFLG(String val) {
        set(Tbj27LogCrCreateData.PAYMONEYFLG, val);
    }

    /**
     * �������z�m�F�t���O���擾����
     *
     * @return �������z�m�F�t���O
     */
    public String getPAYCONFIRMFLG() {
        return (String) get(Tbj27LogCrCreateData.PAYCONFIRMFLG);
    }

    /**
     * �������z�m�F�t���O��ݒ肷��
     *
     * @param val �������z�m�F�t���O
     */
    public void setPAYCONFIRMFLG(String val) {
        set(Tbj27LogCrCreateData.PAYCONFIRMFLG, val);
    }

    /**
     * ���ϋ��z�t���O���擾����
     *
     * @return ���ϋ��z�t���O
     */
    public String getESTMONEYFLG() {
        return (String) get(Tbj27LogCrCreateData.ESTMONEYFLG);
    }

    /**
     * ���ϋ��z�t���O��ݒ肷��
     *
     * @param val ���ϋ��z�t���O
     */
    public void setESTMONEYFLG(String val) {
        set(Tbj27LogCrCreateData.ESTMONEYFLG, val);
    }

    /**
     * �������z�t���O���擾����
     *
     * @return �������z�t���O
     */
    public String getCLMMONEYFLG() {
        return (String) get(Tbj27LogCrCreateData.CLMMONEYFLG);
    }

    /**
     * �������z�t���O��ݒ肷��
     *
     * @param val �������z�t���O
     */
    public void setCLMMONEYFLG(String val) {
        set(Tbj27LogCrCreateData.CLMMONEYFLG, val);
    }

    /**
     * �x����[�i���t���O���擾����
     *
     * @return �x����[�i���t���O
     */
    public String getDELIVERDAYFLG() {
        return (String) get(Tbj27LogCrCreateData.DELIVERDAYFLG);
    }

    /**
     * �x����[�i���t���O��ݒ肷��
     *
     * @param val �x����[�i���t���O
     */
    public void setDELIVERDAYFLG(String val) {
        set(Tbj27LogCrCreateData.DELIVERDAYFLG, val);
    }

    /**
     * �ݒ茎�t���O���擾����
     *
     * @return �ݒ茎�t���O
     */
    public String getSETMONTHFLG() {
        return (String) get(Tbj27LogCrCreateData.SETMONTHFLG);
    }

    /**
     * �ݒ茎�t���O��ݒ肷��
     *
     * @param val �ݒ茎�t���O
     */
    public void setSETMONTHFLG(String val) {
        set(Tbj27LogCrCreateData.SETMONTHFLG, val);
    }

    /**
     * �敪�t���O���擾����
     *
     * @return �敪�t���O
     */
    public String getDIVISIONFLG() {
        return (String) get(Tbj27LogCrCreateData.DIVISIONFLG);
    }

    /**
     * �敪�t���O��ݒ肷��
     *
     * @param val �敪�t���O
     */
    public void setDIVISIONFLG(String val) {
        set(Tbj27LogCrCreateData.DIVISIONFLG, val);
    }

    /**
     * �O���[�v�R�[�h�t���O���擾����
     *
     * @return �O���[�v�R�[�h�t���O
     */
    public String getGROUPCDFLG() {
        return (String) get(Tbj27LogCrCreateData.GROUPCDFLG);
    }

    /**
     * �O���[�v�R�[�h�t���O��ݒ肷��
     *
     * @param val �O���[�v�R�[�h�t���O
     */
    public void setGROUPCDFLG(String val) {
        set(Tbj27LogCrCreateData.GROUPCDFLG, val);
    }

    /**
     * �ݒ�ǃi���o�[�t���O���擾����
     *
     * @return �ݒ�ǃi���o�[�t���O
     */
    public String getSTKYKNOFLG() {
        return (String) get(Tbj27LogCrCreateData.STKYKNOFLG);
    }

    /**
     * �ݒ�ǃi���o�[�t���O��ݒ肷��
     *
     * @param val �ݒ�ǃi���o�[�t���O
     */
    public void setSTKYKNOFLG(String val) {
        set(Tbj27LogCrCreateData.STKYKNOFLG, val);
    }

    /**
     * �ݒ�S���Җ��t���O���擾����
     *
     * @return �ݒ�S���Җ��t���O
     */
    public String getSTTNTNMFLG() {
        return (String) get(Tbj27LogCrCreateData.STTNTNMFLG);
    }

    /**
     * �ݒ�S���Җ��t���O��ݒ肷��
     *
     * @param val �ݒ�S���Җ��t���O
     */
    public void setSTTNTNMFLG(String val) {
        set(Tbj27LogCrCreateData.STTNTNMFLG, val);
    }

    /**
     * �c���`�F�b�N�t���O���擾����
     *
     * @return �c���`�F�b�N�t���O
     */
    public String getEGTYKFLGFLG() {
        return (String) get(Tbj27LogCrCreateData.EGTYKFLGFLG);
    }

    /**
     * �c���`�F�b�N�t���O��ݒ肷��
     *
     * @param val �c���`�F�b�N�t���O
     */
    public void setEGTYKFLGFLG(String val) {
        set(Tbj27LogCrCreateData.EGTYKFLGFLG, val);
    }

    /**
     * ���͒S���R�[�h�t���O���擾����
     *
     * @return ���͒S���R�[�h�t���O
     */
    public String getINPUTTNTCDFLG() {
        return (String) get(Tbj27LogCrCreateData.INPUTTNTCDFLG);
    }

    /**
     * ���͒S���R�[�h�t���O��ݒ肷��
     *
     * @param val ���͒S���R�[�h�t���O
     */
    public void setINPUTTNTCDFLG(String val) {
        set(Tbj27LogCrCreateData.INPUTTNTCDFLG, val);
    }

    /**
     * CP�S���҃t���O���擾����
     *
     * @return CP�S���҃t���O
     */
    public String getCPTNTNMFLG() {
        return (String) get(Tbj27LogCrCreateData.CPTNTNMFLG);
    }

    /**
     * CP�S���҃t���O��ݒ肷��
     *
     * @param val CP�S���҃t���O
     */
    public void setCPTNTNMFLG(String val) {
        set(Tbj27LogCrCreateData.CPTNTNMFLG, val);
    }

    /**
     * ���l�t���O���擾����
     *
     * @return ���l�t���O
     */
    public String getNOTEFLG() {
        return (String) get(Tbj27LogCrCreateData.NOTEFLG);
    }

    /**
     * ���l�t���O��ݒ肷��
     *
     * @param val ���l�t���O
     */
    public void setNOTEFLG(String val) {
        set(Tbj27LogCrCreateData.NOTEFLG, val);
    }

    /**
     * �d�ʎԎ�R�[�h�m�F�t���O���擾����
     *
     * @return �d�ʎԎ�R�[�h�m�F�t���O
     */
    public String getDCARCDCONFFLG() {
        return (String) get(Tbj27LogCrCreateData.DCARCDCONFFLG);
    }

    /**
     * �d�ʎԎ�R�[�h�m�F�t���O��ݒ肷��
     *
     * @param val �d�ʎԎ�R�[�h�m�F�t���O
     */
    public void setDCARCDCONFFLG(String val) {
        set(Tbj27LogCrCreateData.DCARCDCONFFLG, val);
    }

    /**
     * �d�ʎԎ�R�[�h�m�F�g�D�R�[�h���擾����
     *
     * @return �d�ʎԎ�R�[�h�m�F�g�D�R�[�h
     */
    public String getDCARCDCONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.DCARCDCONFSIKCD);
    }

    /**
     * �d�ʎԎ�R�[�h�m�F�g�D�R�[�h��ݒ肷��
     *
     * @param val �d�ʎԎ�R�[�h�m�F�g�D�R�[�h
     */
    public void setDCARCDCONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.DCARCDCONFSIKCD, val);
    }

    /**
     * �d�ʎԎ�R�[�h�m�F�S���҃R�[�h���擾����
     *
     * @return �d�ʎԎ�R�[�h�m�F�S���҃R�[�h
     */
    public String getDCARCDCONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.DCARCDCONFHAMID);
    }

    /**
     * �d�ʎԎ�R�[�h�m�F�S���҃R�[�h��ݒ肷��
     *
     * @param val �d�ʎԎ�R�[�h�m�F�S���҃R�[�h
     */
    public void setDCARCDCONFHAMID(String val) {
        set(Tbj27LogCrCreateData.DCARCDCONFHAMID, val);
    }

    /**
     * �\�Z�\���ފm�F�t���O���擾����
     *
     * @return �\�Z�\���ފm�F�t���O
     */
    public String getCLASSCDCONFFLG() {
        return (String) get(Tbj27LogCrCreateData.CLASSCDCONFFLG);
    }

    /**
     * �\�Z�\���ފm�F�t���O��ݒ肷��
     *
     * @param val �\�Z�\���ފm�F�t���O
     */
    public void setCLASSCDCONFFLG(String val) {
        set(Tbj27LogCrCreateData.CLASSCDCONFFLG, val);
    }

    /**
     * �\�Z�\���ފm�F�g�D�R�[�h���擾����
     *
     * @return �\�Z�\���ފm�F�g�D�R�[�h
     */
    public String getCLASSCDCONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.CLASSCDCONFSIKCD);
    }

    /**
     * �\�Z�\���ފm�F�g�D�R�[�h��ݒ肷��
     *
     * @param val �\�Z�\���ފm�F�g�D�R�[�h
     */
    public void setCLASSCDCONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.CLASSCDCONFSIKCD, val);
    }

    /**
     * �\�Z�\���ފm�F�S���҃R�[�h���擾����
     *
     * @return �\�Z�\���ފm�F�S���҃R�[�h
     */
    public String getCLASSCDCONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.CLASSCDCONFHAMID);
    }

    /**
     * �\�Z�\���ފm�F�S���҃R�[�h��ݒ肷��
     *
     * @param val �\�Z�\���ފm�F�S���҃R�[�h
     */
    public void setCLASSCDCONFHAMID(String val) {
        set(Tbj27LogCrCreateData.CLASSCDCONFHAMID, val);
    }

    /**
     * �\�Z�\��ڊm�F�t���O���擾����
     *
     * @return �\�Z�\��ڊm�F�t���O
     */
    public String getEXPCDCONFFLG() {
        return (String) get(Tbj27LogCrCreateData.EXPCDCONFFLG);
    }

    /**
     * �\�Z�\��ڊm�F�t���O��ݒ肷��
     *
     * @param val �\�Z�\��ڊm�F�t���O
     */
    public void setEXPCDCONFFLG(String val) {
        set(Tbj27LogCrCreateData.EXPCDCONFFLG, val);
    }

    /**
     * �\�Z�\��ڊm�F�g�D�R�[�h���擾����
     *
     * @return �\�Z�\��ڊm�F�g�D�R�[�h
     */
    public String getEXPCDCONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.EXPCDCONFSIKCD);
    }

    /**
     * �\�Z�\��ڊm�F�g�D�R�[�h��ݒ肷��
     *
     * @param val �\�Z�\��ڊm�F�g�D�R�[�h
     */
    public void setEXPCDCONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.EXPCDCONFSIKCD, val);
    }

    /**
     * �\�Z�\��ڊm�F�S���҃R�[�h���擾����
     *
     * @return �\�Z�\��ڊm�F�S���҃R�[�h
     */
    public String getEXPCDCONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.EXPCDCONFHAMID);
    }

    /**
     * �\�Z�\��ڊm�F�S���҃R�[�h��ݒ肷��
     *
     * @param val �\�Z�\��ڊm�F�S���҃R�[�h
     */
    public void setEXPCDCONFHAMID(String val) {
        set(Tbj27LogCrCreateData.EXPCDCONFHAMID, val);
    }

    /**
     * ��ڊm�F�t���O���擾����
     *
     * @return ��ڊm�F�t���O
     */
    public String getEXPENSECONFFLG() {
        return (String) get(Tbj27LogCrCreateData.EXPENSECONFFLG);
    }

    /**
     * ��ڊm�F�t���O��ݒ肷��
     *
     * @param val ��ڊm�F�t���O
     */
    public void setEXPENSECONFFLG(String val) {
        set(Tbj27LogCrCreateData.EXPENSECONFFLG, val);
    }

    /**
     * ��ڊm�F�g�D�R�[�h���擾����
     *
     * @return ��ڊm�F�g�D�R�[�h
     */
    public String getEXPENSECONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.EXPENSECONFSIKCD);
    }

    /**
     * ��ڊm�F�g�D�R�[�h��ݒ肷��
     *
     * @param val ��ڊm�F�g�D�R�[�h
     */
    public void setEXPENSECONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.EXPENSECONFSIKCD, val);
    }

    /**
     * ��ڊm�F�S���҃R�[�h���擾����
     *
     * @return ��ڊm�F�S���҃R�[�h
     */
    public String getEXPENSECONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.EXPENSECONFHAMID);
    }

    /**
     * ��ڊm�F�S���҃R�[�h��ݒ肷��
     *
     * @param val ��ڊm�F�S���҃R�[�h
     */
    public void setEXPENSECONFHAMID(String val) {
        set(Tbj27LogCrCreateData.EXPENSECONFHAMID, val);
    }

    /**
     * �ڍ׊m�F�t���O���擾����
     *
     * @return �ڍ׊m�F�t���O
     */
    public String getDETAILCONFFLG() {
        return (String) get(Tbj27LogCrCreateData.DETAILCONFFLG);
    }

    /**
     * �ڍ׊m�F�t���O��ݒ肷��
     *
     * @param val �ڍ׊m�F�t���O
     */
    public void setDETAILCONFFLG(String val) {
        set(Tbj27LogCrCreateData.DETAILCONFFLG, val);
    }

    /**
     * �ڍ׊m�F�g�D�R�[�h���擾����
     *
     * @return �ڍ׊m�F�g�D�R�[�h
     */
    public String getDETAILCONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.DETAILCONFSIKCD);
    }

    /**
     * �ڍ׊m�F�g�D�R�[�h��ݒ肷��
     *
     * @param val �ڍ׊m�F�g�D�R�[�h
     */
    public void setDETAILCONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.DETAILCONFSIKCD, val);
    }

    /**
     * �ڍ׊m�F�S���҃R�[�h���擾����
     *
     * @return �ڍ׊m�F�S���҃R�[�h
     */
    public String getDETAILCONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.DETAILCONFHAMID);
    }

    /**
     * �ڍ׊m�F�S���҃R�[�h��ݒ肷��
     *
     * @param val �ڍ׊m�F�S���҃R�[�h
     */
    public void setDETAILCONFHAMID(String val) {
        set(Tbj27LogCrCreateData.DETAILCONFHAMID, val);
    }

    /**
     * ���ԊJ�n�m�F�t���O���擾����
     *
     * @return ���ԊJ�n�m�F�t���O
     */
    public String getKIKANSCONFFLG() {
        return (String) get(Tbj27LogCrCreateData.KIKANSCONFFLG);
    }

    /**
     * ���ԊJ�n�m�F�t���O��ݒ肷��
     *
     * @param val ���ԊJ�n�m�F�t���O
     */
    public void setKIKANSCONFFLG(String val) {
        set(Tbj27LogCrCreateData.KIKANSCONFFLG, val);
    }

    /**
     * ���ԊJ�n�m�F�g�D�R�[�h���擾����
     *
     * @return ���ԊJ�n�m�F�g�D�R�[�h
     */
    public String getKIKANSCONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.KIKANSCONFSIKCD);
    }

    /**
     * ���ԊJ�n�m�F�g�D�R�[�h��ݒ肷��
     *
     * @param val ���ԊJ�n�m�F�g�D�R�[�h
     */
    public void setKIKANSCONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.KIKANSCONFSIKCD, val);
    }

    /**
     * ���ԊJ�n�m�F�S���҃R�[�h���擾����
     *
     * @return ���ԊJ�n�m�F�S���҃R�[�h
     */
    public String getKIKANSCONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.KIKANSCONFHAMID);
    }

    /**
     * ���ԊJ�n�m�F�S���҃R�[�h��ݒ肷��
     *
     * @param val ���ԊJ�n�m�F�S���҃R�[�h
     */
    public void setKIKANSCONFHAMID(String val) {
        set(Tbj27LogCrCreateData.KIKANSCONFHAMID, val);
    }

    /**
     * ���ԏI���m�F�t���O���擾����
     *
     * @return ���ԏI���m�F�t���O
     */
    public String getKIKANECONFFLG() {
        return (String) get(Tbj27LogCrCreateData.KIKANECONFFLG);
    }

    /**
     * ���ԏI���m�F�t���O��ݒ肷��
     *
     * @param val ���ԏI���m�F�t���O
     */
    public void setKIKANECONFFLG(String val) {
        set(Tbj27LogCrCreateData.KIKANECONFFLG, val);
    }

    /**
     * ���ԏI���m�F�g�D�R�[�h���擾����
     *
     * @return ���ԏI���m�F�g�D�R�[�h
     */
    public String getKIKANECONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.KIKANECONFSIKCD);
    }

    /**
     * ���ԏI���m�F�g�D�R�[�h��ݒ肷��
     *
     * @param val ���ԏI���m�F�g�D�R�[�h
     */
    public void setKIKANECONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.KIKANECONFSIKCD, val);
    }

    /**
     * ���ԏI���m�F�S���҃R�[�h���擾����
     *
     * @return ���ԏI���m�F�S���҃R�[�h
     */
    public String getKIKANECONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.KIKANECONFHAMID);
    }

    /**
     * ���ԏI���m�F�S���҃R�[�h��ݒ肷��
     *
     * @param val ���ԏI���m�F�S���҃R�[�h
     */
    public void setKIKANECONFHAMID(String val) {
        set(Tbj27LogCrCreateData.KIKANECONFHAMID, val);
    }

    /**
     * �_��J�n�N�����m�F�t���O���擾����
     *
     * @return �_��J�n�N�����m�F�t���O
     */
    public String getCONTRACTDATECONFFLG() {
        return (String) get(Tbj27LogCrCreateData.CONTRACTDATECONFFLG);
    }

    /**
     * �_��J�n�N�����m�F�t���O��ݒ肷��
     *
     * @param val �_��J�n�N�����m�F�t���O
     */
    public void setCONTRACTDATECONFFLG(String val) {
        set(Tbj27LogCrCreateData.CONTRACTDATECONFFLG, val);
    }

    /**
     * �_��J�n�N�����m�F�g�D�R�[�h���擾����
     *
     * @return �_��J�n�N�����m�F�g�D�R�[�h
     */
    public String getCONTRACTDATECONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.CONTRACTDATECONFSIKCD);
    }

    /**
     * �_��J�n�N�����m�F�g�D�R�[�h��ݒ肷��
     *
     * @param val �_��J�n�N�����m�F�g�D�R�[�h
     */
    public void setCONTRACTDATECONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.CONTRACTDATECONFSIKCD, val);
    }

    /**
     * �_��J�n�N�����m�F�S���҃R�[�h���擾����
     *
     * @return �_��J�n�N�����m�F�S���҃R�[�h
     */
    public String getCONTRACTDATECONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.CONTRACTDATECONFHAMID);
    }

    /**
     * �_��J�n�N�����m�F�S���҃R�[�h��ݒ肷��
     *
     * @param val �_��J�n�N�����m�F�S���҃R�[�h
     */
    public void setCONTRACTDATECONFHAMID(String val) {
        set(Tbj27LogCrCreateData.CONTRACTDATECONFHAMID, val);
    }

    /**
     * �_�����(����)�m�F�t���O���擾����
     *
     * @return �_�����(����)�m�F�t���O
     */
    public String getCONTRACTTERMCONFFLG() {
        return (String) get(Tbj27LogCrCreateData.CONTRACTTERMCONFFLG);
    }

    /**
     * �_�����(����)�m�F�t���O��ݒ肷��
     *
     * @param val �_�����(����)�m�F�t���O
     */
    public void setCONTRACTTERMCONFFLG(String val) {
        set(Tbj27LogCrCreateData.CONTRACTTERMCONFFLG, val);
    }

    /**
     * �_�����(����)�m�F�g�D�R�[�h���擾����
     *
     * @return �_�����(����)�m�F�g�D�R�[�h
     */
    public String getCONTRACTTERMCONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.CONTRACTTERMCONFSIKCD);
    }

    /**
     * �_�����(����)�m�F�g�D�R�[�h��ݒ肷��
     *
     * @param val �_�����(����)�m�F�g�D�R�[�h
     */
    public void setCONTRACTTERMCONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.CONTRACTTERMCONFSIKCD, val);
    }

    /**
     * �_�����(����)�m�F�S���҃R�[�h���擾����
     *
     * @return �_�����(����)�m�F�S���҃R�[�h
     */
    public String getCONTRACTTERMCONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.CONTRACTTERMCONFHAMID);
    }

    /**
     * �_�����(����)�m�F�S���҃R�[�h��ݒ肷��
     *
     * @param val �_�����(����)�m�F�S���҃R�[�h
     */
    public void setCONTRACTTERMCONFHAMID(String val) {
        set(Tbj27LogCrCreateData.CONTRACTTERMCONFHAMID, val);
    }

    /**
     * ������m�F�t���O���擾����
     *
     * @return ������m�F�t���O
     */
    public String getSEIKYUCONFFLG() {
        return (String) get(Tbj27LogCrCreateData.SEIKYUCONFFLG);
    }

    /**
     * ������m�F�t���O��ݒ肷��
     *
     * @param val ������m�F�t���O
     */
    public void setSEIKYUCONFFLG(String val) {
        set(Tbj27LogCrCreateData.SEIKYUCONFFLG, val);
    }

    /**
     * ������m�F�g�D�R�[�h���擾����
     *
     * @return ������m�F�g�D�R�[�h
     */
    public String getSEIKYUCONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.SEIKYUCONFSIKCD);
    }

    /**
     * ������m�F�g�D�R�[�h��ݒ肷��
     *
     * @param val ������m�F�g�D�R�[�h
     */
    public void setSEIKYUCONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.SEIKYUCONFSIKCD, val);
    }

    /**
     * ������m�F�S���҃R�[�h���擾����
     *
     * @return ������m�F�S���҃R�[�h
     */
    public String getSEIKYUCONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.SEIKYUCONFHAMID);
    }

    /**
     * ������m�F�S���҃R�[�h��ݒ肷��
     *
     * @param val ������m�F�S���҃R�[�h
     */
    public void setSEIKYUCONFHAMID(String val) {
        set(Tbj27LogCrCreateData.SEIKYUCONFHAMID, val);
    }

    /**
     * ��NO�m�F�t���O���擾����
     *
     * @return ��NO�m�F�t���O
     */
    public String getORDERNOCONFFLG() {
        return (String) get(Tbj27LogCrCreateData.ORDERNOCONFFLG);
    }

    /**
     * ��NO�m�F�t���O��ݒ肷��
     *
     * @param val ��NO�m�F�t���O
     */
    public void setORDERNOCONFFLG(String val) {
        set(Tbj27LogCrCreateData.ORDERNOCONFFLG, val);
    }

    /**
     * ��NO�m�F�g�D�R�[�h���擾����
     *
     * @return ��NO�m�F�g�D�R�[�h
     */
    public String getORDERNOCONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.ORDERNOCONFSIKCD);
    }

    /**
     * ��NO�m�F�g�D�R�[�h��ݒ肷��
     *
     * @param val ��NO�m�F�g�D�R�[�h
     */
    public void setORDERNOCONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.ORDERNOCONFSIKCD, val);
    }

    /**
     * ��NO�m�F�S���҃R�[�h���擾����
     *
     * @return ��NO�m�F�S���҃R�[�h
     */
    public String getORDERNOCONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.ORDERNOCONFHAMID);
    }

    /**
     * ��NO�m�F�S���҃R�[�h��ݒ肷��
     *
     * @param val ��NO�m�F�S���҃R�[�h
     */
    public void setORDERNOCONFHAMID(String val) {
        set(Tbj27LogCrCreateData.ORDERNOCONFHAMID, val);
    }

    /**
     * �x����m�F�t���O���擾����
     *
     * @return �x����m�F�t���O
     */
    public String getPAYCONFFLG() {
        return (String) get(Tbj27LogCrCreateData.PAYCONFFLG);
    }

    /**
     * �x����m�F�t���O��ݒ肷��
     *
     * @param val �x����m�F�t���O
     */
    public void setPAYCONFFLG(String val) {
        set(Tbj27LogCrCreateData.PAYCONFFLG, val);
    }

    /**
     * �x����m�F�g�D�R�[�h���擾����
     *
     * @return �x����m�F�g�D�R�[�h
     */
    public String getPAYCONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.PAYCONFSIKCD);
    }

    /**
     * �x����m�F�g�D�R�[�h��ݒ肷��
     *
     * @param val �x����m�F�g�D�R�[�h
     */
    public void setPAYCONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.PAYCONFSIKCD, val);
    }

    /**
     * �x����m�F�S���҃R�[�h���擾����
     *
     * @return �x����m�F�S���҃R�[�h
     */
    public String getPAYCONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.PAYCONFHAMID);
    }

    /**
     * �x����m�F�S���҃R�[�h��ݒ肷��
     *
     * @param val �x����m�F�S���҃R�[�h
     */
    public void setPAYCONFHAMID(String val) {
        set(Tbj27LogCrCreateData.PAYCONFHAMID, val);
    }

    /**
     * �S���Ҋm�F�t���O���擾����
     *
     * @return �S���Ҋm�F�t���O
     */
    public String getUSERNAMECONFFLG() {
        return (String) get(Tbj27LogCrCreateData.USERNAMECONFFLG);
    }

    /**
     * �S���Ҋm�F�t���O��ݒ肷��
     *
     * @param val �S���Ҋm�F�t���O
     */
    public void setUSERNAMECONFFLG(String val) {
        set(Tbj27LogCrCreateData.USERNAMECONFFLG, val);
    }

    /**
     * �S���Ҋm�F�g�D�R�[�h���擾����
     *
     * @return �S���Ҋm�F�g�D�R�[�h
     */
    public String getUSERNAMECONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.USERNAMECONFSIKCD);
    }

    /**
     * �S���Ҋm�F�g�D�R�[�h��ݒ肷��
     *
     * @param val �S���Ҋm�F�g�D�R�[�h
     */
    public void setUSERNAMECONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.USERNAMECONFSIKCD, val);
    }

    /**
     * �S���Ҋm�F�S���҃R�[�h���擾����
     *
     * @return �S���Ҋm�F�S���҃R�[�h
     */
    public String getUSERNAMECONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.USERNAMECONFHAMID);
    }

    /**
     * �S���Ҋm�F�S���҃R�[�h��ݒ肷��
     *
     * @param val �S���Ҋm�F�S���҃R�[�h
     */
    public void setUSERNAMECONFHAMID(String val) {
        set(Tbj27LogCrCreateData.USERNAMECONFHAMID, val);
    }

    /**
     * �����z�m�F�t���O���擾����
     *
     * @return �����z�m�F�t���O
     */
    public String getGETMONEYCONFFLG() {
        return (String) get(Tbj27LogCrCreateData.GETMONEYCONFFLG);
    }

    /**
     * �����z�m�F�t���O��ݒ肷��
     *
     * @param val �����z�m�F�t���O
     */
    public void setGETMONEYCONFFLG(String val) {
        set(Tbj27LogCrCreateData.GETMONEYCONFFLG, val);
    }

    /**
     * �����z�m�F�g�D�R�[�h���擾����
     *
     * @return �����z�m�F�g�D�R�[�h
     */
    public String getGETMONEYCONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.GETMONEYCONFSIKCD);
    }

    /**
     * �����z�m�F�g�D�R�[�h��ݒ肷��
     *
     * @param val �����z�m�F�g�D�R�[�h
     */
    public void setGETMONEYCONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.GETMONEYCONFSIKCD, val);
    }

    /**
     * �����z�m�F�S���҃R�[�h���擾����
     *
     * @return �����z�m�F�S���҃R�[�h
     */
    public String getGETMONEYCONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.GETMONEYCONFHAMID);
    }

    /**
     * �����z�m�F�S���҃R�[�h��ݒ肷��
     *
     * @param val �����z�m�F�S���҃R�[�h
     */
    public void setGETMONEYCONFHAMID(String val) {
        set(Tbj27LogCrCreateData.GETMONEYCONFHAMID, val);
    }

    /**
     * �����z�m�F�m�F�t���O���擾����
     *
     * @return �����z�m�F�m�F�t���O
     */
    public String getGETCONFCONFFLG() {
        return (String) get(Tbj27LogCrCreateData.GETCONFCONFFLG);
    }

    /**
     * �����z�m�F�m�F�t���O��ݒ肷��
     *
     * @param val �����z�m�F�m�F�t���O
     */
    public void setGETCONFCONFFLG(String val) {
        set(Tbj27LogCrCreateData.GETCONFCONFFLG, val);
    }

    /**
     * �����z�m�F�m�F�g�D�R�[�h���擾����
     *
     * @return �����z�m�F�m�F�g�D�R�[�h
     */
    public String getGETCONFCONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.GETCONFCONFSIKCD);
    }

    /**
     * �����z�m�F�m�F�g�D�R�[�h��ݒ肷��
     *
     * @param val �����z�m�F�m�F�g�D�R�[�h
     */
    public void setGETCONFCONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.GETCONFCONFSIKCD, val);
    }

    /**
     * �����z�m�F�m�F�S���҃R�[�h���擾����
     *
     * @return �����z�m�F�m�F�S���҃R�[�h
     */
    public String getGETCONFCONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.GETCONFCONFHAMID);
    }

    /**
     * �����z�m�F�m�F�S���҃R�[�h��ݒ肷��
     *
     * @param val �����z�m�F�m�F�S���҃R�[�h
     */
    public void setGETCONFCONFHAMID(String val) {
        set(Tbj27LogCrCreateData.GETCONFCONFHAMID, val);
    }

    /**
     * �������z�m�F�t���O���擾����
     *
     * @return �������z�m�F�t���O
     */
    public String getPAYMONEYCONFFLG() {
        return (String) get(Tbj27LogCrCreateData.PAYMONEYCONFFLG);
    }

    /**
     * �������z�m�F�t���O��ݒ肷��
     *
     * @param val �������z�m�F�t���O
     */
    public void setPAYMONEYCONFFLG(String val) {
        set(Tbj27LogCrCreateData.PAYMONEYCONFFLG, val);
    }

    /**
     * �������z�m�F�g�D�R�[�h���擾����
     *
     * @return �������z�m�F�g�D�R�[�h
     */
    public String getPAYMONEYCONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.PAYMONEYCONFSIKCD);
    }

    /**
     * �������z�m�F�g�D�R�[�h��ݒ肷��
     *
     * @param val �������z�m�F�g�D�R�[�h
     */
    public void setPAYMONEYCONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.PAYMONEYCONFSIKCD, val);
    }

    /**
     * �������z�m�F�S���҃R�[�h���擾����
     *
     * @return �������z�m�F�S���҃R�[�h
     */
    public String getPAYMONEYCONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.PAYMONEYCONFHAMID);
    }

    /**
     * �������z�m�F�S���҃R�[�h��ݒ肷��
     *
     * @param val �������z�m�F�S���҃R�[�h
     */
    public void setPAYMONEYCONFHAMID(String val) {
        set(Tbj27LogCrCreateData.PAYMONEYCONFHAMID, val);
    }

    /**
     * �������z�m�F�m�F�t���O���擾����
     *
     * @return �������z�m�F�m�F�t���O
     */
    public String getPAYCONFCONFFLG() {
        return (String) get(Tbj27LogCrCreateData.PAYCONFCONFFLG);
    }

    /**
     * �������z�m�F�m�F�t���O��ݒ肷��
     *
     * @param val �������z�m�F�m�F�t���O
     */
    public void setPAYCONFCONFFLG(String val) {
        set(Tbj27LogCrCreateData.PAYCONFCONFFLG, val);
    }

    /**
     * �������z�m�F�m�F�g�D�R�[�h���擾����
     *
     * @return �������z�m�F�m�F�g�D�R�[�h
     */
    public String getPAYCONFCONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.PAYCONFCONFSIKCD);
    }

    /**
     * �������z�m�F�m�F�g�D�R�[�h��ݒ肷��
     *
     * @param val �������z�m�F�m�F�g�D�R�[�h
     */
    public void setPAYCONFCONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.PAYCONFCONFSIKCD, val);
    }

    /**
     * �������z�m�F�m�F�S���҃R�[�h���擾����
     *
     * @return �������z�m�F�m�F�S���҃R�[�h
     */
    public String getPAYCONFCONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.PAYCONFCONFHAMID);
    }

    /**
     * �������z�m�F�m�F�S���҃R�[�h��ݒ肷��
     *
     * @param val �������z�m�F�m�F�S���҃R�[�h
     */
    public void setPAYCONFCONFHAMID(String val) {
        set(Tbj27LogCrCreateData.PAYCONFCONFHAMID, val);
    }

    /**
     * ���ϋ��z�m�F�t���O���擾����
     *
     * @return ���ϋ��z�m�F�t���O
     */
    public String getESTMONEYCONFFLG() {
        return (String) get(Tbj27LogCrCreateData.ESTMONEYCONFFLG);
    }

    /**
     * ���ϋ��z�m�F�t���O��ݒ肷��
     *
     * @param val ���ϋ��z�m�F�t���O
     */
    public void setESTMONEYCONFFLG(String val) {
        set(Tbj27LogCrCreateData.ESTMONEYCONFFLG, val);
    }

    /**
     * ���ϋ��z�m�F�g�D�R�[�h���擾����
     *
     * @return ���ϋ��z�m�F�g�D�R�[�h
     */
    public String getESTMONEYCONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.ESTMONEYCONFSIKCD);
    }

    /**
     * ���ϋ��z�m�F�g�D�R�[�h��ݒ肷��
     *
     * @param val ���ϋ��z�m�F�g�D�R�[�h
     */
    public void setESTMONEYCONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.ESTMONEYCONFSIKCD, val);
    }

    /**
     * ���ϋ��z�m�F�S���҃R�[�h���擾����
     *
     * @return ���ϋ��z�m�F�S���҃R�[�h
     */
    public String getESTMONEYCONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.ESTMONEYCONFHAMID);
    }

    /**
     * ���ϋ��z�m�F�S���҃R�[�h��ݒ肷��
     *
     * @param val ���ϋ��z�m�F�S���҃R�[�h
     */
    public void setESTMONEYCONFHAMID(String val) {
        set(Tbj27LogCrCreateData.ESTMONEYCONFHAMID, val);
    }

    /**
     * �������z�m�F�t���O���擾����
     *
     * @return �������z�m�F�t���O
     */
    public String getCLMMONEYCONFFLG() {
        return (String) get(Tbj27LogCrCreateData.CLMMONEYCONFFLG);
    }

    /**
     * �������z�m�F�t���O��ݒ肷��
     *
     * @param val �������z�m�F�t���O
     */
    public void setCLMMONEYCONFFLG(String val) {
        set(Tbj27LogCrCreateData.CLMMONEYCONFFLG, val);
    }

    /**
     * �������z�m�F�g�D�R�[�h���擾����
     *
     * @return �������z�m�F�g�D�R�[�h
     */
    public String getCLMMONEYCONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.CLMMONEYCONFSIKCD);
    }

    /**
     * �������z�m�F�g�D�R�[�h��ݒ肷��
     *
     * @param val �������z�m�F�g�D�R�[�h
     */
    public void setCLMMONEYCONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.CLMMONEYCONFSIKCD, val);
    }

    /**
     * �������z�m�F�S���҃R�[�h���擾����
     *
     * @return �������z�m�F�S���҃R�[�h
     */
    public String getCLMMONEYCONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.CLMMONEYCONFHAMID);
    }

    /**
     * �������z�m�F�S���҃R�[�h��ݒ肷��
     *
     * @param val �������z�m�F�S���҃R�[�h
     */
    public void setCLMMONEYCONFHAMID(String val) {
        set(Tbj27LogCrCreateData.CLMMONEYCONFHAMID, val);
    }

    /**
     * �x����[�i���m�F�t���O���擾����
     *
     * @return �x����[�i���m�F�t���O
     */
    public String getDELIVERDAYCONFFLG() {
        return (String) get(Tbj27LogCrCreateData.DELIVERDAYCONFFLG);
    }

    /**
     * �x����[�i���m�F�t���O��ݒ肷��
     *
     * @param val �x����[�i���m�F�t���O
     */
    public void setDELIVERDAYCONFFLG(String val) {
        set(Tbj27LogCrCreateData.DELIVERDAYCONFFLG, val);
    }

    /**
     * �x����[�i���m�F�g�D�R�[�h���擾����
     *
     * @return �x����[�i���m�F�g�D�R�[�h
     */
    public String getDELIVERDAYCONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.DELIVERDAYCONFSIKCD);
    }

    /**
     * �x����[�i���m�F�g�D�R�[�h��ݒ肷��
     *
     * @param val �x����[�i���m�F�g�D�R�[�h
     */
    public void setDELIVERDAYCONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.DELIVERDAYCONFSIKCD, val);
    }

    /**
     * �x����[�i���m�F�S���҃R�[�h���擾����
     *
     * @return �x����[�i���m�F�S���҃R�[�h
     */
    public String getDELIVERDAYCONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.DELIVERDAYCONFHAMID);
    }

    /**
     * �x����[�i���m�F�S���҃R�[�h��ݒ肷��
     *
     * @param val �x����[�i���m�F�S���҃R�[�h
     */
    public void setDELIVERDAYCONFHAMID(String val) {
        set(Tbj27LogCrCreateData.DELIVERDAYCONFHAMID, val);
    }

    /**
     * �ݒ茎�m�F�t���O���擾����
     *
     * @return �ݒ茎�m�F�t���O
     */
    public String getSETMONTHCONFFLG() {
        return (String) get(Tbj27LogCrCreateData.SETMONTHCONFFLG);
    }

    /**
     * �ݒ茎�m�F�t���O��ݒ肷��
     *
     * @param val �ݒ茎�m�F�t���O
     */
    public void setSETMONTHCONFFLG(String val) {
        set(Tbj27LogCrCreateData.SETMONTHCONFFLG, val);
    }

    /**
     * �ݒ茎�m�F�g�D�R�[�h���擾����
     *
     * @return �ݒ茎�m�F�g�D�R�[�h
     */
    public String getSETMONTHCONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.SETMONTHCONFSIKCD);
    }

    /**
     * �ݒ茎�m�F�g�D�R�[�h��ݒ肷��
     *
     * @param val �ݒ茎�m�F�g�D�R�[�h
     */
    public void setSETMONTHCONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.SETMONTHCONFSIKCD, val);
    }

    /**
     * �ݒ茎�m�F�S���҃R�[�h���擾����
     *
     * @return �ݒ茎�m�F�S���҃R�[�h
     */
    public String getSETMONTHCONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.SETMONTHCONFHAMID);
    }

    /**
     * �ݒ茎�m�F�S���҃R�[�h��ݒ肷��
     *
     * @param val �ݒ茎�m�F�S���҃R�[�h
     */
    public void setSETMONTHCONFHAMID(String val) {
        set(Tbj27LogCrCreateData.SETMONTHCONFHAMID, val);
    }

    /**
     * �敪�R�[�h�m�F�t���O���擾����
     *
     * @return �敪�R�[�h�m�F�t���O
     */
    public String getDIVISIONCONFFLG() {
        return (String) get(Tbj27LogCrCreateData.DIVISIONCONFFLG);
    }

    /**
     * �敪�R�[�h�m�F�t���O��ݒ肷��
     *
     * @param val �敪�R�[�h�m�F�t���O
     */
    public void setDIVISIONCONFFLG(String val) {
        set(Tbj27LogCrCreateData.DIVISIONCONFFLG, val);
    }

    /**
     * �敪�R�[�h�m�F�g�D�R�[�h���擾����
     *
     * @return �敪�R�[�h�m�F�g�D�R�[�h
     */
    public String getDIVISIONCONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.DIVISIONCONFSIKCD);
    }

    /**
     * �敪�R�[�h�m�F�g�D�R�[�h��ݒ肷��
     *
     * @param val �敪�R�[�h�m�F�g�D�R�[�h
     */
    public void setDIVISIONCONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.DIVISIONCONFSIKCD, val);
    }

    /**
     * �敪�R�[�h�m�F�S���҃R�[�h���擾����
     *
     * @return �敪�R�[�h�m�F�S���҃R�[�h
     */
    public String getDIVISIONCONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.DIVISIONCONFHAMID);
    }

    /**
     * �敪�R�[�h�m�F�S���҃R�[�h��ݒ肷��
     *
     * @param val �敪�R�[�h�m�F�S���҃R�[�h
     */
    public void setDIVISIONCONFHAMID(String val) {
        set(Tbj27LogCrCreateData.DIVISIONCONFHAMID, val);
    }

    /**
     * �O���[�v�R�[�h�m�F�t���O���擾����
     *
     * @return �O���[�v�R�[�h�m�F�t���O
     */
    public String getGROUPCDCONFFLG() {
        return (String) get(Tbj27LogCrCreateData.GROUPCDCONFFLG);
    }

    /**
     * �O���[�v�R�[�h�m�F�t���O��ݒ肷��
     *
     * @param val �O���[�v�R�[�h�m�F�t���O
     */
    public void setGROUPCDCONFFLG(String val) {
        set(Tbj27LogCrCreateData.GROUPCDCONFFLG, val);
    }

    /**
     * �O���[�v�R�[�h�m�F�g�D�R�[�h���擾����
     *
     * @return �O���[�v�R�[�h�m�F�g�D�R�[�h
     */
    public String getGROUPCDCONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.GROUPCDCONFSIKCD);
    }

    /**
     * �O���[�v�R�[�h�m�F�g�D�R�[�h��ݒ肷��
     *
     * @param val �O���[�v�R�[�h�m�F�g�D�R�[�h
     */
    public void setGROUPCDCONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.GROUPCDCONFSIKCD, val);
    }

    /**
     * �O���[�v�R�[�h�m�F�S���҃R�[�h���擾����
     *
     * @return �O���[�v�R�[�h�m�F�S���҃R�[�h
     */
    public String getGROUPCDCONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.GROUPCDCONFHAMID);
    }

    /**
     * �O���[�v�R�[�h�m�F�S���҃R�[�h��ݒ肷��
     *
     * @param val �O���[�v�R�[�h�m�F�S���҃R�[�h
     */
    public void setGROUPCDCONFHAMID(String val) {
        set(Tbj27LogCrCreateData.GROUPCDCONFHAMID, val);
    }

    /**
     * �ݒ�ǃi���o�[�m�F�t���O���擾����
     *
     * @return �ݒ�ǃi���o�[�m�F�t���O
     */
    public String getSTKYKNOCONFFLG() {
        return (String) get(Tbj27LogCrCreateData.STKYKNOCONFFLG);
    }

    /**
     * �ݒ�ǃi���o�[�m�F�t���O��ݒ肷��
     *
     * @param val �ݒ�ǃi���o�[�m�F�t���O
     */
    public void setSTKYKNOCONFFLG(String val) {
        set(Tbj27LogCrCreateData.STKYKNOCONFFLG, val);
    }

    /**
     * �ݒ�ǃi���o�[�m�F�g�D�R�[�h���擾����
     *
     * @return �ݒ�ǃi���o�[�m�F�g�D�R�[�h
     */
    public String getSTKYKNOCONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.STKYKNOCONFSIKCD);
    }

    /**
     * �ݒ�ǃi���o�[�m�F�g�D�R�[�h��ݒ肷��
     *
     * @param val �ݒ�ǃi���o�[�m�F�g�D�R�[�h
     */
    public void setSTKYKNOCONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.STKYKNOCONFSIKCD, val);
    }

    /**
     * �ݒ�ǃi���o�[�m�F�S���҃R�[�h���擾����
     *
     * @return �ݒ�ǃi���o�[�m�F�S���҃R�[�h
     */
    public String getSTKYKNOCONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.STKYKNOCONFHAMID);
    }

    /**
     * �ݒ�ǃi���o�[�m�F�S���҃R�[�h��ݒ肷��
     *
     * @param val �ݒ�ǃi���o�[�m�F�S���҃R�[�h
     */
    public void setSTKYKNOCONFHAMID(String val) {
        set(Tbj27LogCrCreateData.STKYKNOCONFHAMID, val);
    }

    /**
     * �ݒ�S���Җ��m�F�t���O���擾����
     *
     * @return �ݒ�S���Җ��m�F�t���O
     */
    public String getSTTNTNMCONFFLG() {
        return (String) get(Tbj27LogCrCreateData.STTNTNMCONFFLG);
    }

    /**
     * �ݒ�S���Җ��m�F�t���O��ݒ肷��
     *
     * @param val �ݒ�S���Җ��m�F�t���O
     */
    public void setSTTNTNMCONFFLG(String val) {
        set(Tbj27LogCrCreateData.STTNTNMCONFFLG, val);
    }

    /**
     * �ݒ�S���Җ��m�F�g�D�R�[�h���擾����
     *
     * @return �ݒ�S���Җ��m�F�g�D�R�[�h
     */
    public String getSTTNTNMCONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.STTNTNMCONFSIKCD);
    }

    /**
     * �ݒ�S���Җ��m�F�g�D�R�[�h��ݒ肷��
     *
     * @param val �ݒ�S���Җ��m�F�g�D�R�[�h
     */
    public void setSTTNTNMCONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.STTNTNMCONFSIKCD, val);
    }

    /**
     * �ݒ�S���Җ��m�F�S���҃R�[�h���擾����
     *
     * @return �ݒ�S���Җ��m�F�S���҃R�[�h
     */
    public String getSTTNTNMCONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.STTNTNMCONFHAMID);
    }

    /**
     * �ݒ�S���Җ��m�F�S���҃R�[�h��ݒ肷��
     *
     * @param val �ݒ�S���Җ��m�F�S���҃R�[�h
     */
    public void setSTTNTNMCONFHAMID(String val) {
        set(Tbj27LogCrCreateData.STTNTNMCONFHAMID, val);
    }

    /**
     * �c���`�F�b�N�m�F�t���O���擾����
     *
     * @return �c���`�F�b�N�m�F�t���O
     */
    public String getEGTYKCONFFLG() {
        return (String) get(Tbj27LogCrCreateData.EGTYKCONFFLG);
    }

    /**
     * �c���`�F�b�N�m�F�t���O��ݒ肷��
     *
     * @param val �c���`�F�b�N�m�F�t���O
     */
    public void setEGTYKCONFFLG(String val) {
        set(Tbj27LogCrCreateData.EGTYKCONFFLG, val);
    }

    /**
     * �c���`�F�b�N�m�F�g�D�R�[�h���擾����
     *
     * @return �c���`�F�b�N�m�F�g�D�R�[�h
     */
    public String getEGTYKCONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.EGTYKCONFSIKCD);
    }

    /**
     * �c���`�F�b�N�m�F�g�D�R�[�h��ݒ肷��
     *
     * @param val �c���`�F�b�N�m�F�g�D�R�[�h
     */
    public void setEGTYKCONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.EGTYKCONFSIKCD, val);
    }

    /**
     * �c���`�F�b�N�m�F�S���҃R�[�h���擾����
     *
     * @return �c���`�F�b�N�m�F�S���҃R�[�h
     */
    public String getEGTYKCONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.EGTYKCONFHAMID);
    }

    /**
     * �c���`�F�b�N�m�F�S���҃R�[�h��ݒ肷��
     *
     * @param val �c���`�F�b�N�m�F�S���҃R�[�h
     */
    public void setEGTYKCONFHAMID(String val) {
        set(Tbj27LogCrCreateData.EGTYKCONFHAMID, val);
    }

    /**
     * ���͒S���R�[�h�m�F�t���O���擾����
     *
     * @return ���͒S���R�[�h�m�F�t���O
     */
    public String getINPUTTNTCDCONFFLG() {
        return (String) get(Tbj27LogCrCreateData.INPUTTNTCDCONFFLG);
    }

    /**
     * ���͒S���R�[�h�m�F�t���O��ݒ肷��
     *
     * @param val ���͒S���R�[�h�m�F�t���O
     */
    public void setINPUTTNTCDCONFFLG(String val) {
        set(Tbj27LogCrCreateData.INPUTTNTCDCONFFLG, val);
    }

    /**
     * ���͒S���R�[�h�m�F�g�D�R�[�h���擾����
     *
     * @return ���͒S���R�[�h�m�F�g�D�R�[�h
     */
    public String getINPUTTNTCDCONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.INPUTTNTCDCONFSIKCD);
    }

    /**
     * ���͒S���R�[�h�m�F�g�D�R�[�h��ݒ肷��
     *
     * @param val ���͒S���R�[�h�m�F�g�D�R�[�h
     */
    public void setINPUTTNTCDCONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.INPUTTNTCDCONFSIKCD, val);
    }

    /**
     * ���͒S���R�[�h�m�F�S���҃R�[�h���擾����
     *
     * @return ���͒S���R�[�h�m�F�S���҃R�[�h
     */
    public String getINPUTTNTCDCONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.INPUTTNTCDCONFHAMID);
    }

    /**
     * ���͒S���R�[�h�m�F�S���҃R�[�h��ݒ肷��
     *
     * @param val ���͒S���R�[�h�m�F�S���҃R�[�h
     */
    public void setINPUTTNTCDCONFHAMID(String val) {
        set(Tbj27LogCrCreateData.INPUTTNTCDCONFHAMID, val);
    }

    /**
     * CP�S���Ҋm�F�t���O���擾����
     *
     * @return CP�S���Ҋm�F�t���O
     */
    public String getCPTNTNMCONFFLG() {
        return (String) get(Tbj27LogCrCreateData.CPTNTNMCONFFLG);
    }

    /**
     * CP�S���Ҋm�F�t���O��ݒ肷��
     *
     * @param val CP�S���Ҋm�F�t���O
     */
    public void setCPTNTNMCONFFLG(String val) {
        set(Tbj27LogCrCreateData.CPTNTNMCONFFLG, val);
    }

    /**
     * CP�S���Ҋm�F�g�D�R�[�h���擾����
     *
     * @return CP�S���Ҋm�F�g�D�R�[�h
     */
    public String getCPTNTNMCONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.CPTNTNMCONFSIKCD);
    }

    /**
     * CP�S���Ҋm�F�g�D�R�[�h��ݒ肷��
     *
     * @param val CP�S���Ҋm�F�g�D�R�[�h
     */
    public void setCPTNTNMCONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.CPTNTNMCONFSIKCD, val);
    }

    /**
     * CP�S���Ҋm�F�S���҃R�[�h���擾����
     *
     * @return CP�S���Ҋm�F�S���҃R�[�h
     */
    public String getCPTNTNMCONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.CPTNTNMCONFHAMID);
    }

    /**
     * CP�S���Ҋm�F�S���҃R�[�h��ݒ肷��
     *
     * @param val CP�S���Ҋm�F�S���҃R�[�h
     */
    public void setCPTNTNMCONFHAMID(String val) {
        set(Tbj27LogCrCreateData.CPTNTNMCONFHAMID, val);
    }

    /**
     * ���l�m�F�t���O���擾����
     *
     * @return ���l�m�F�t���O
     */
    public String getNOTECONFFLG() {
        return (String) get(Tbj27LogCrCreateData.NOTECONFFLG);
    }

    /**
     * ���l�m�F�t���O��ݒ肷��
     *
     * @param val ���l�m�F�t���O
     */
    public void setNOTECONFFLG(String val) {
        set(Tbj27LogCrCreateData.NOTECONFFLG, val);
    }

    /**
     * ���l�m�F�g�D�R�[�h���擾����
     *
     * @return ���l�m�F�g�D�R�[�h
     */
    public String getNOTECONFSIKCD() {
        return (String) get(Tbj27LogCrCreateData.NOTECONFSIKCD);
    }

    /**
     * ���l�m�F�g�D�R�[�h��ݒ肷��
     *
     * @param val ���l�m�F�g�D�R�[�h
     */
    public void setNOTECONFSIKCD(String val) {
        set(Tbj27LogCrCreateData.NOTECONFSIKCD, val);
    }

    /**
     * ���l�m�F�S���҃R�[�h���擾����
     *
     * @return ���l�m�F�S���҃R�[�h
     */
    public String getNOTECONFHAMID() {
        return (String) get(Tbj27LogCrCreateData.NOTECONFHAMID);
    }

    /**
     * ���l�m�F�S���҃R�[�h��ݒ肷��
     *
     * @param val ���l�m�F�S���҃R�[�h
     */
    public void setNOTECONFHAMID(String val) {
        set(Tbj27LogCrCreateData.NOTECONFHAMID, val);
    }

    /**
     * �f�[�^�쐬�������擾����
     *
     * @return �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj27LogCrCreateData.CRTDATE);
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     *
     * @param val �f�[�^�쐬����
     */
    public void setCRTDATE(Date val) {
        set(Tbj27LogCrCreateData.CRTDATE, val);
    }

    /**
     * �f�[�^�쐬�҂��擾����
     *
     * @return �f�[�^�쐬��
     */
    public String getCRTNM() {
        return (String) get(Tbj27LogCrCreateData.CRTNM);
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     *
     * @param val �f�[�^�쐬��
     */
    public void setCRTNM(String val) {
        set(Tbj27LogCrCreateData.CRTNM, val);
    }

    /**
     * �쐬�v���O�������擾����
     *
     * @return �쐬�v���O����
     */
    public String getCRTAPL() {
        return (String) get(Tbj27LogCrCreateData.CRTAPL);
    }

    /**
     * �쐬�v���O������ݒ肷��
     *
     * @param val �쐬�v���O����
     */
    public void setCRTAPL(String val) {
        set(Tbj27LogCrCreateData.CRTAPL, val);
    }

    /**
     * �쐬�S����ID���擾����
     *
     * @return �쐬�S����ID
     */
    public String getCRTID() {
        return (String) get(Tbj27LogCrCreateData.CRTID);
    }

    /**
     * �쐬�S����ID��ݒ肷��
     *
     * @param val �쐬�S����ID
     */
    public void setCRTID(String val) {
        set(Tbj27LogCrCreateData.CRTID, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj27LogCrCreateData.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Tbj27LogCrCreateData.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Tbj27LogCrCreateData.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Tbj27LogCrCreateData.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Tbj27LogCrCreateData.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Tbj27LogCrCreateData.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Tbj27LogCrCreateData.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Tbj27LogCrCreateData.UPDID, val);
    }

}