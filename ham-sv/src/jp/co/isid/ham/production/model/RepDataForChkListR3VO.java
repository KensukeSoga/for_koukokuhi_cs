package jp.co.isid.ham.production.model;

import java.math.BigDecimal;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * BudgetDAO.findBudget�Ŏ擾�����f�[�^���i�[����VO�N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/07 �VHAM�`�[��)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */

@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class RepDataForChkListR3VO extends AbstractModel {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepDataForChkListR3VO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new RepDataForChkListR3VO();
    }

    /**
     * ���Ӑ��ƃR�[�h���擾����
     *
     * @return ���Ӑ��ƃR�[�h
     */
    public String getTKSKGYCD() {
        return (String) get("TKSKGYCD");
    }

    /**
     * ���Ӑ��ƃR�[�h��ݒ肷��
     *
     * @param val ���Ӑ��ƃR�[�h
     */
    public void setTKSKGYCD(String val) {
        set("TKSKGYCD", val);
    }

    /**
     * ���Ӑ敔��R�[�h���擾����
     *
     * @return ���Ӑ敔��R�[�h
     */
    public String getTKSBMNSEQNO() {
        return (String) get("TKSBMNSEQNO");
    }

    /**
     * ���Ӑ敔��R�[�h��ݒ肷��
     *
     * @param val ���Ӑ敔��R�[�h
     */
    public void setTKSBMNSEQNO(String val) {
        set("TKSBMNSEQNO", val);
    }

    /**
     * ���Ӑ�S���R�[�h���擾����
     *
     * @return ���Ӑ�S���R�[�h
     */
    public String getTKSTNTSEQNO() {
        return (String) get("TKSTNTSEQNO");
    }

    /**
     * ���Ӑ�S���R�[�h��ݒ肷��
     *
     * @param val ���Ӑ�S���R�[�h
     */
    public void setTKSTNTSEQNO(String val) {
        set("TKSTNTSEQNO", val);
    }

    /**
     * ��ڂ��擾����
     *
     * @return ���
     */
    public String getHMOKNM() {
        return (String) get("HMOKNM");
    }

    /**
     * ��ڂ�ݒ肷��
     *
     * @param val ���
     */
    public void setHMOKNM(String val) {
        set("HMOKNM", val);
    }
    /**
     * �������擾����
     *
     * @return ����
     */
    public String getKKNAMEJ() {
        return (String) get("KKNAMEJ");
    }

    /**
     * ������ݒ肷��
     *
     * @param val ����
     */
    public void setKKNAMEJ(String val) {
        set("KKNAMEJ", val);
    }
    /**
     * �⑫���e���擾����
     *
     * @return �⑫���e
     */
    public String getHOSOK() {
        return (String) get("HOSOK");
    }

    /**
     * �⑫���e��ݒ肷��
     *
     * @param val �⑫���e
     */
    public void setHOSOK(String val) {
        set("HOSOK", val);
    }
    /**
     * ����FROM(�N�j���擾����
     *
     * @return ����FROM(�N�j
     */
    public String getTERMFRYY() {
        return (String) get("TERMFRYY");
    }

    /**
     * ����FROM(�N�j��ݒ肷��
     *
     * @param val ����FROM(�N�j
     */
    public void setTERMFRYY(String val) {
        set("TERMFRYY", val);
    }
    /**
     * ����FROM(���j���擾����
     *
     * @return ����FROM(���j
     */
    public String getTERMFRMM() {
        return (String) get("TERMFRMM");
    }

    /**
     * ����FROM(���j��ݒ肷��
     *
     * @param val ����FROM(���j
     */
    public void setTERMFRMM(String val) {
        set("TERMFRMM", val);
    }
    /**
     * ����FROM(���j���擾����
     *
     * @return ����FROM(���j
     */
    public String getTERMFRDD() {
        return (String) get("TERMFRDD");
    }

    /**
     * ����FROM(���j��ݒ肷��
     *
     * @param val ����FROM(���j
     */
    public void setTERMFRDD(String val) {
        set("TERMFRDD", val);
    }
    /**
     * ����TO(�N�j���擾����
     *
     * @return ����TO(�N�j
     */
    public String getTERMTOYY() {
        return (String) get("TERMTOYY");
    }

    /**
     * ����TO(�N�j��ݒ肷��
     *
     * @param val ����TO(�N�j
     */
    public void setTERMTOYY(String val) {
        set("TERMTOYY", val);
    }
    /**
     * ����TO(���j���擾����
     *
     * @return ����TO(���j
     */
    public String getTERMTOMM() {
        return (String) get("TERMTOMM");
    }

    /**
     * ����TO(���j��ݒ肷��
     *
     * @param val ����TO(���j
     */
    public void setTERMTOMM(String val) {
        set("TERMTOMM", val);
    }
    /**
     * ����TO(���j���擾����
     *
     * @return ����TO(���j
     */
    public String getTERMTODD() {
        return (String) get("TERMTODD");
    }

    /**
     * ����TO(���j��ݒ肷��
     *
     * @param val ����TO(���j
     */
    public void setTERMTODD(String val) {
        set("TERMTODD", val);
    }
    /**
     * �[�i�����擾����
     *
     * @return �[�i��
     */
    public String getKEISYMD() {
        return (String) get("KEISYMD");
    }

    /**
     * �[�i����ݒ肷��
     *
     * @param val �[�i��
     */
    public void setKEISYMD(String val) {
        set("KEISYMD", val);
    }
    /**
     * �����z���擾����
     *
     * @return �����z
     */
    public BigDecimal getTRGAK() {
        return (BigDecimal) get("TRGAK");
    }

    /**
     * �����z��ݒ肷��
     *
     * @param val �����z
     */
    public void setTRGAK(BigDecimal val) {
        set("TRGAK", val);
    }
    /**
     * �l�����z���擾����
     *
     * @return �l�����z
     */
    public BigDecimal getNEBIGAK() {
        return (BigDecimal) get("NEBIGAK");
    }

    /**
     * �l�����z��ݒ肷��
     *
     * @param val �l�����z
     */
    public void setNEBIGAK(BigDecimal val) {
        set("NEBIGAK", val);
    }
    /**
     * �敪���擾����
     *
     * @return �敪
     */
    public String getKBNNM() {
        return (String) get("KBNNM");
    }

    /**
     * �敪��ݒ肷��
     *
     * @param val �敪
     */
    public void setKBNNM(String val) {
        set("KBNNM", val);
    }

    /**
     * �����ǂ��擾����
     *
     * @return ������
     */
    public String getKYOKUNM() {
        return (String) get("KYOKUNM");
    }

    /**
     * �����ǂ�ݒ肷��
     *
     * @param val ������
     */
    public void setKYOKUNM(String val) {
        set("KYOKUNM", val);
    }

    /**
     * ��NO���擾����
     *
     * @return ��NO
     */
    public String getJYUTNO() {
        return (String) get("JYUTNO");
    }

    /**
     * ��NO��ݒ肷��
     *
     * @param val ��NO
     */
    public void setJYUTNO(String val) {
        set("JYUTNO", val);
    }

    /**
     * �󒍖���SEQNO���擾����
     *
     * @return �󒍖���SEQNO
     */
    public String getJYMEISEQ() {
        return (String) get("JYMEISEQ");
    }

    /**
     * �󒍖���SEQNO��ݒ肷��
     *
     * @param val �󒍖���SEQNO
     */
    public void setJYMEISEQ(String val) {
        set("JYMEISEQ", val);
    }

    /**
     * �S���҃R�[�h���擾����
     *
     * @return �S���҃R�[�h
     */
    public String getEGTNTCD() {
        return (String) get("EGTNTCD");
    }

    /**
     * �S���҃R�[�h��ݒ肷��
     *
     * @param val �S���҃R�[�h
     */
    public void setEGTNTCD(String val) {
        set("EGTNTCD", val);
    }

    /**
     * �S���Җ����擾����
     *
     * @return �S���Җ�
     */
    public String getEGTNTNM() {
        return (String) get("EGTNTNM");
    }

    /**
     * �S���Җ���ݒ肷��
     *
     * @param val �S���Җ�
     */
    public void setEGTNTNM(String val) {
        set("EGTNTNM", val);
    }
}
