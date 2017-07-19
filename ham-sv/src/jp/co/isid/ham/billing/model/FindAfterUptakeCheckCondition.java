package jp.co.isid.ham.billing.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �ύX�m�F��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/3/13 HLC H.Watabe)<BR>
 * </P>
 * @author H.watabe
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindAfterUptakeCheckCondition implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �t�F�C�Y
     */
    private int _phase = 0;

    /**
     * �N��
     */
    private String _yearMonth = null;

    /**
     * ��ʔ��f�t���O
     */
    private String _classdiv = null;

    /**
     * �t�F�C�Y���擾����
     *
     * @return �t�F�C�Y
     */
    public int getPhase() {
        return _phase;
    }

    /**
     * �t�F�C�Y��ݒ肷��
     *
     * @param phase �t�F�C�Y
     */
    public void setPhase(int phase) {
        _phase = phase;
    }

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
     * ��ʔ��f�t���O���擾����
     *
     * @return ��ʔ��f�t���O
     */
    public String getClassDiv() {
        return _classdiv;
    }

    /**
     * ��ʔ��f�t���O��ݒ肷��
     *
     * @param classdiv ��ʔ��f�t���O
     */
    public void setClassDiv(String classdiv) {
        _classdiv = classdiv;
    }
}
