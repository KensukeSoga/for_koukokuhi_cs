package jp.co.isid.ham.common.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * �ꗗ�\���p�^�[����ێ�����
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/11 K.Fukuda)<BR>
 * </P>
 * @author K.Fukuda
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj30DisplayPatternResult extends AbstractServiceResult{

    /**
     * �ꗗ�\���p�^�[��VO���X�g
     */
    private Tbj30DisplayPatternVO _dp;

    /**
     * �ꗗ�\���p�^�[��VO���X�g���擾���܂�
     * @return  �ꗗ�\���p�^�[��VO���X�g
     */
    public Tbj30DisplayPatternVO getDisplayPattern() {
        return _dp;
    }

    /**
     * �ꗗ�\���p�^�[��VO���X�g��ݒ肵�܂�
     * @param dc  �ꗗ�\���p�^�[��VO���X�g
     */
    public void setDisplayControlList(Tbj30DisplayPatternVO dp) {
        _dp = dp;
    }

}
