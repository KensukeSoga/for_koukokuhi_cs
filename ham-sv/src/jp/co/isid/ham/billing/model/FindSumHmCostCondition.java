package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.util.List;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * H�V���f���R�X�g���v��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/4/10 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindSumHmCostCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �N��
     */
    private String _yearMonth = null;

    /**
     * �d�ʎԎ�R�[�h
     */
    private List<String> _dcarCd;

    /**
     * �}�̃R�[�h
     */
    private List<String> _mediaCd;


    /**
     * �N�����擾����
     *
     * @return �N��
     */
    public String getYearMonth() {
        return _yearMonth;
    }

    /**
     * �N����ݒ肷��
     *
     * @param yearMonth �N��
     */
    public void setYearMonth(String yearMonth) {
        _yearMonth = yearMonth;
    }

    /**
     * �d�ʎԎ�R�[�h���擾����
     *
     * @return �d�ʎԎ�R�[�h
     */
    public List<String> getDCarCd() {
        return _dcarCd;
    }

    /**
     * �d�ʎԎ�R�[�h��ݒ肷��
     *
     * @param dcarCd �d�ʎԎ�R�[�h
     */
    public void setDCarCd(List<String> dcarCd) {
        _dcarCd = dcarCd;
    }

    /**
     * �}�̃R�[�h���擾����
     *
     * @return �}�̃R�[�h
     */
    public List<String> getMediaCd() {
        return _mediaCd;
    }

    /**
     * �}�̃R�[�h��ݒ肷��
     *
     * @param mediaCd �}�̃R�[�h
     */
    public void setMediaCd(List<String> mediaCd) {
        _mediaCd = mediaCd;
    }
}
