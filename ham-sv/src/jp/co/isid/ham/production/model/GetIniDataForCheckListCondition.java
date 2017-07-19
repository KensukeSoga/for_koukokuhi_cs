package jp.co.isid.ham.production.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * CR�����@�N�����f�[�^�擾�̏����N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/30 �VHAM�`�[��)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class GetIniDataForCheckListCondition implements Serializable {

    /**
     * serialVersionUID
     */
    private static final long serialVersionUID = 1L;

    /** ���(YYYYMMDD) */
    private String _baseDate = null;

    /**
     * ������擾����
     *
     * @return ���
     */
    public String getBaseDate() {
        return _baseDate;
    }

    /**
     * �����ݒ肷��
     *
     * @param userid ���
     */
    public void setBaseDate(String baseDate) {
        this._baseDate = baseDate;
    }
}
