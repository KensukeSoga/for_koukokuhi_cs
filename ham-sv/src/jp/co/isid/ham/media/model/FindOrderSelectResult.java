package jp.co.isid.ham.media.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
*
* <P>
* �󒍃t�@�C���o�͉�ʂ̏���ێ�����.
* </P>
* <P>
* <B>�C������</B><BR>
* �E�V�K�쐬(2013/02/18 HLC H.Watabe)<BR>
* </P>
* @author HLC H.Watabe
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindOrderSelectResult extends AbstractServiceResult {

    /** �c�ƍ�Ƒ䒠VO */
    private List<FindOrderSelectVO> _orderSelvo;


    /** ��ʍ��ڕ\���񐧌�}�X�^ */
    private List<Mbj37DisplayControlVO> _dc;

    /**
     * �c�ƍ�Ƒ䒠���擾
     * @return �c�ƍ�Ƒ䒠
     */
    public List<FindOrderSelectVO> getOrderSelect() {
        return _orderSelvo;
    }

    /**
     * �c�ƍ�Ƒ䒠��ݒ�
     * @param daichovo
     */
    public void setOrderSelect(List<FindOrderSelectVO> orderSelvo) {
        this._orderSelvo = orderSelvo;
    }

    /**
     * ��ʍ��ڕ\���񐧌�}�X�^���擾����
     *
     * @return ��ʍ��ڕ\���񐧌�}�X�^
     */
    public List<Mbj37DisplayControlVO> getDisplayControl() {
        return _dc;
    }

    /**
     * ��ʍ��ڕ\���񐧌�}�X�^��ݒ肷��
     *
     * @param dc ��ʍ��ڕ\���񐧌�}�X�^
     */
    public void setDisplayControl(List<Mbj37DisplayControlVO> dc) {
        _dc = dc;
    }

    /** List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ� */
    private String _dummy;

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ����擾���܂�
     * @return String �_�~�[�v���p�e�B
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ���ݒ肵�܂�
     * @param dummy �_�~�[�v���p�e�B
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }
}
