package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj50RdStation;
import jp.co.isid.ham.integ.tbl.Tbj17Content;
import jp.co.isid.ham.integ.tbl.Tbj20SozaiKanriList;
import jp.co.isid.ham.integ.tbl.Tbj37RdProgram;
import jp.co.isid.ham.integ.tbl.Tbj38RdProgramMaterial;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �c�ƍ�Ƒ䒠���W�I�^�C���C���|�[�g��񌟍�VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/12/11 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindRdTime2AccountBookVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ���� */
    public static final String CNT = "CNT";

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindRdTime2AccountBookVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new FindRdTime2AccountBookVO();
    }

    /**
     * ���W�I�ԑgSEQNO���擾����
     * @return BigDecimal ���W�I�ԑgSEQNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getRDSEQNO() {
        return (BigDecimal) get(Tbj38RdProgramMaterial.RDSEQNO);
    }

    /**
     * ���W�I�ԑgSEQNO��ݒ肷��
     * @param val BigDecimal ���W�I�ԑgSEQNO
     */
    public void setRDSEQNO(BigDecimal val) {
        set(Tbj38RdProgramMaterial  .RDSEQNO, val);
    }

    /**
     * �Ԏ�R�[�h���擾����
     * @return String �Ԏ�R�[�h
     */
    public String getDCARCD() {
        return (String) get(Tbj20SozaiKanriList.DCARCD);
    }

    /**
     * �Ԏ�R�[�h��ݒ肷��
     * @param val String �Ԏ�R�[�h
     */
    public void setDCARCD(String val) {
        set(Tbj20SozaiKanriList.DCARCD, val);
    }

    /**
     * �n��R�[�h���擾����
     * @return String �n��R�[�h
     */
    public String getKEIRETSUCD() {
        return (String) get(Mbj05Car.KEIRETSUCD);
    }

    /**
     * �n��R�[�h��ݒ肷��
     * @param val String �n��R�[�h
     */
    public void setKEIRETSUCD(String val) {
        set(Mbj05Car.KEIRETSUCD, val);
    }

    /**
     * �����ǖ����擾����
     * @return String �����ǖ�
     */
    public String getRDSTATION() {
        return (String) get(Mbj50RdStation.ABBREVIATION);
    }

    /**
     * �����ǖ���ݒ肷��
     * @param val String �����ǖ�
     */
    public void setRDSTATION(String val) {
        set(Mbj50RdStation.ABBREVIATION, val);
    }

    /**
     * �ԑg�����擾����
     * @return String �ԑg��
     */
    public String getPROGRAMNM() {
        return (String) get(Tbj37RdProgram.PROGRAMNM);
    }

    /**
     * �ԑg����ݒ肷��
     * @param val String �ԑg��
     */
    public void setPROGRAMNM(String val) {
        set(Tbj37RdProgram.PROGRAMNM, val);
    }

    /**
     * �}�̖��̂��擾����
     * @return String �}�̖���
     */
    public String getMEDIANM() {
       return (String) get(Mbj03Media.MEDIANM);
    }

    /**
     * �}�̖��̂�ݒ肷��
     * @param val String �}�̖���
     */
    public void setMEDIANM(String val) {
        set(Mbj03Media.MEDIANM, val);
    }

    /**
     * 10��CM�R�[�h���擾����
     * @return String 10��CM�R�[�h
     */
    public String getCMCD() {
        return (String) get(Tbj17Content.CMCD);
    }

    /**
     * 10��CM�R�[�h��ݒ肷��
     * @param val String 10��CM�R�[�h
     */
    public void setCMCD(String val) {
        set(Tbj17Content.CMCD, val);
    }

    /**
     * ���R�[�h���擾����
     * @return String ���R�[�h
     */
    public String getRCODE() {
        return (String) get(Tbj20SozaiKanriList.RCODE);
    }

    /**
     * ���R�[�h��ݒ肷��
     * @param val String ���R�[�h
     */
    public void setRCODE(String val) {
        set(Tbj20SozaiKanriList.RCODE, val);
    }

    /**
     * �b�����擾����
     * @return BigDecimal �b��
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSECOND() {
        return (BigDecimal) get(Tbj20SozaiKanriList.SECOND);
    }

    /**
     * �b����ݒ肷��
     * @param val BigDecimal �b��
     */
    public void setSECOND(BigDecimal val) {
        set(Tbj20SozaiKanriList.SECOND, val);
    }

    /**
     * �����J�n�����擾����
     * @return Date �����J�n��
     */
    @XmlElement(required = true, nillable = true)
    public Date getSTARTDATE() {
        return (Date) get(Tbj37RdProgram.DATEFROM);
    }

    /**
     * �����J�n����ݒ肷��
     * @param val Date �����J�n��
     */
    public void setSTARTDATE(Date val) {
        set(Tbj37RdProgram.DATEFROM, val);
    }

    /**
     * �����I�������擾����
     * @return Date �����I����
     */
    @XmlElement(required = true, nillable = true)
    public Date getENDDATE() {
        return (Date) get(Tbj37RdProgram.DATETO);
    }

    /**
     * �����I������ݒ肷��
     * @param val Date �����I����
     */
    public void setENDDATE(Date val) {
        set(Tbj37RdProgram.DATETO, val);
    }

    /**
     * �����j�����擾����
     * @return String �����j��
     */
    public String getONAIRDAY() {
        return (String) get(Tbj37RdProgram.ONAIRMON);
    }

    /**
     * �����j����ݒ肷��
     * @param val String �����j��
     */
    public void setONAIRDAY(String val) {
        set(Tbj37RdProgram.ONAIRMON, val);
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

}
