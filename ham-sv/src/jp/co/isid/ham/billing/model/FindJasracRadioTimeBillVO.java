package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj16ContractInfo;
import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj20SozaiKanriList;
import jp.co.isid.ham.integ.tbl.Tbj37RdProgram;
import jp.co.isid.ham.integ.tbl.Tbj38RdProgramMaterial;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * JASRAC�������׏�(���W�I�^�C��)����VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/11/19 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindJasracRadioTimeBillVO extends AbstractModel {

    /** ���� */
    private static final String CNT = "CNT";

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindJasracRadioTimeBillVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    @Override
    public Object newInstance() {
        return new FindJasracRadioTimeBillVO();
    }

    /**
     * �_��R�[�h���擾����
     * @return String �_��R�[�h
     */
    public String getCTRTNO() {
        return (String) get(Tbj16ContractInfo.CTRTNO);
    }

    /**
     * �_��R�[�h��ݒ肷��
     * @param val String �_��R�[�h
     */
    public void setCTRTNO(String val) {
        set(Tbj16ContractInfo.CTRTNO, val);
    }

    /**
     * �Ԏ�R�[�h���擾����
     * @return String �Ԏ�R�[�h
     */
    public String getDCARCD() {
        return (String) get(Tbj16ContractInfo.DCARCD);
    }

    /**
     * �Ԏ�R�[�h��ݒ肷��
     * @param val String �Ԏ�R�[�h
     */
    public void setDCARCD(String val) {
        set(Tbj16ContractInfo.DCARCD, val);
    }

    /**
     * �Ԏ햼���擾����
     * @return String �Ԏ햼
     */
    public String getCARNM() {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * �Ԏ햼��ݒ肷��
     * @param val String �Ԏ햼
     */
    public void setCARNM(String val) {
        set(Mbj05Car.CARNM, val);
    }

    /**
     * �y�Ȗ����擾����
     * @return String �y�Ȗ�
     */
    public String getMUSIC() {
        return (String) get(Tbj16ContractInfo.MUSIC);
    }

    /**
     * �y�Ȗ���ݒ肷��
     * @param val String �y�Ȗ�
     */
    public void setMUSIC(String val) {
        set(Tbj16ContractInfo.MUSIC, val);
    }

    /**
     * ���̂��擾����
     * @return String ����
     */
    public String getNAMES() {
        return (String) get(Tbj16ContractInfo.NAMES);
    }

    /**
     * ���̂�ݒ肷��
     * @param val String ����
     */
    public void setNAMES(String val) {
        set(Tbj16ContractInfo.NAMES, val);
    }

    /**
     * 10��CM�R�[�h���擾����
     * @return String 10��CM�R�[�h
     */
    public String getCMCD() {
        return (String) get(Tbj18SozaiKanriData.CMCD);
    }

    /**
     * 10��CM�R�[�h��ݒ肷��
     * @param val String 10��CM�R�[�h
     */
    public void setCMCD(String val) {
        set(Tbj18SozaiKanriData.CMCD, val);
    }

    /**
     * �������擾����
     * @return BigDecimal ����
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCNT() {
        return (BigDecimal) get(CNT);
    }

    /**
     * ������ݒ肷��
     * @param val BigDecimal ����
     */
    public void setCNT(BigDecimal val) {
        set(CNT, val);
    }

    /**
     * ���W�I�ԑgSEQNO���擾����
     * @return BigDecimal ���W�I�ԑgSEQNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getRDSEQNO() {
        return (BigDecimal) get(Tbj37RdProgram.RDSEQNO);
    }

    /**
     * ���W�I�ԑgSEQNO��ݒ肷��
     * @param val BigDecimal ���W�I�ԑgSEQNO
     */
    public void setRDSEQNO(BigDecimal val) {
        set(Tbj37RdProgram.RDSEQNO, val);
    }

    /**
     * �N�����擾����
     * @return String �N��
     */
    public String getYEARMONTH() {
        return (String) get(Tbj38RdProgramMaterial.YEARMONTH);
    }

    /**
     * �N����ݒ肷��
     * @param val String �N��
     */
    public void setYEARMONTH(String val) {
        set(Tbj38RdProgramMaterial.YEARMONTH, val);
    }

    /**
     * ����񋟗����敪���擾����
     * @return String ����񋟗����敪
     */
    public String getSALESPRICEDIV() {
        return (String) get(Tbj37RdProgram.SALESPRICEDIV);
    }

    /**
     * ����񋟗����敪��ݒ肷��
     * @param val String ����񋟗����敪
     */
    public void setSALESPRICEDIV(String val) {
        set(Tbj37RdProgram.SALESPRICEDIV, val);
    }

    /**
     * ����񋟗������擾����
     * @return BigDecimal ����񋟗���
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSALESPRICE() {
        return (BigDecimal) get(Tbj37RdProgram.SALESPRICE);
    }

    /**
     * ����񋟗�����ݒ肷��
     * @param val BigDecimal ����񋟗���
     */
    public void setSALESPRICE(BigDecimal val) {
        set(Tbj37RdProgram.SALESPRICE, val);
    }

    /**
     * �b�����擾����
     * @return String �b��
     */
    public String getSECOND() {
        return (String) get(Tbj20SozaiKanriList.SECOND);
    }

    /**
     * �b����ݒ肷��
     * @param val String �b��
     */
    public void setSECOND(String val) {
        set(Tbj20SozaiKanriList.SECOND, val);
    }

}
